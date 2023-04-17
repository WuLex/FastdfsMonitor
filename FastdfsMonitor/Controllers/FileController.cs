using FastDFSCore;
using FastdfsMonitor.Dtos;
using FastdfsMonitor.Entities;
using FastdfsMonitor.Extensions;
using FastdfsMonitor.Models;
using FastdfsMonitor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace FastdfsMonitor.Controllers
{
    public class FileController : Controller
    {
        private readonly IFastDFSService _fastDFSService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly RocketDbContext _rocketDbContext;

        public FileController(IFastDFSService fastDFSService, RocketDbContext rocketDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _fastDFSService = fastDFSService;
            _webHostEnvironment = webHostEnvironment;
            _rocketDbContext = rocketDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取数据库文件记录
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PageDataResult<FastdfsFileInfo>> GetFilesAsync([FromBody] FastdfsFileQueryDto queryDto)
        {
            try
            {
                int offsetNum = 0, pagesize = 100;
                if (queryDto.Page >= 1 && queryDto.Limit > 0)
                {
                    offsetNum = (queryDto.Page - 1) * queryDto.Limit;
                }
                else
                {
                    queryDto.Limit = pagesize;
                }

                List<FastdfsFileInfo> list = _rocketDbContext.FastDFSFileInfo.OrderBy(b => b.UploadTime).Skip(offsetNum).Take(queryDto.Limit).ToList();

                return new PageDataResult<FastdfsFileInfo>()
                {
                    Msg = "success",
                    Code = 0,
                    Count = _rocketDbContext.FastDFSFileInfo.Count(),
                    Data = list
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            try
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "temp", file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var fileId = await _fastDFSService.UploadAsync("group1", filePath);

                if (!string.IsNullOrEmpty(fileId))
                {
                    // 创建 FastDFSFileInfo 对象
                    var fileInfo = new FastdfsFileInfo
                    {
                        FileId = fileId,
                        FileName = file.FileName,
                        FileType = filePath.GetPathExtension(),
                        FileSize = file.Length.ToMb().ToString(),
                        UploadTime = DateTime.Now
                    };

                    // 将 FastdfsFileInfo 对象保存到 SQL Server
                    _rocketDbContext.FastDFSFileInfo.Add(fileInfo);
                    await _rocketDbContext.SaveChangesAsync();
                    System.IO.File.Delete(filePath);

                    return Json(new { Code = 200, Msg = fileId });
                    //return Ok(fileId);
                }
                else
                {
                    return BadRequest("上传失败");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadAsync(int id = 0)
        {
            try
            {
                var fastdfsFileInfo = await _rocketDbContext.FastDFSFileInfo.FirstOrDefaultAsync(x => x.Id == id);

                if (fastdfsFileInfo != null)
                {
                    var fileId = fastdfsFileInfo.FileId;
                    var fileBytes = await _fastDFSService.DownloadAsync("group1", fileId);

                    if (fileBytes != null)
                    {
                        return File(fileBytes, "application/octet-stream", fastdfsFileInfo.FileName);
                    }
                    else
                    {
                        return StatusCode(404, "文件不存在");
                    }
                }
                else
                {
                    return StatusCode(404, "文件不存在");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var fastdfsFileInfo = await _rocketDbContext.FastDFSFileInfo.FirstOrDefaultAsync(x => x.Id == id); 
                if (fastdfsFileInfo != null)
                {
                    var fileId = fastdfsFileInfo.FileId;

                    #region 开始事务
                    using (var transaction = _rocketDbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            // 删除数据库记录
                            _rocketDbContext.FastDFSFileInfo.Remove(fastdfsFileInfo);

                            // 删除FastDFS文件
                            var deletedflag = await _fastDFSService.DeleteAsync("group1", fileId);
                            if (deletedflag)
                            {
                                // 提交事务
                                await _rocketDbContext.SaveChangesAsync();
                                transaction.Commit();
                                return Json(new { Code = 200, Msg = "删除图片成功" });
                            }
                            else
                            {
                                transaction.Rollback();
                                return Json(new { Code = 500, Msg = "删除图片失败" });
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return Json(new { Code = 500, Msg = ex.Message });
                        }
                    }
                    #endregion
                }
                else
                {
                    return Json(new { Code = 404, Msg = "文件不存在" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Code = 500, Msg = ex.Message });
            }
        }
    }
}