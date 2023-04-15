using FastdfsMonitor.Entities;
using FastdfsMonitor.Extensions;
using FastdfsMonitor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace FastdfsMonitor.Controllers
{
    public class FileController : Controller
    {
        private readonly FastDFSService _fastDFSService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly RocketDbContext _rocketDbContext;
        public FileController(FastDFSService fastDFSService, RocketDbContext rocketDbContext,IWebHostEnvironment webHostEnvironment)
        {
            _fastDFSService = fastDFSService;
            _webHostEnvironment = webHostEnvironment;
            _rocketDbContext = rocketDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            try
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "temp", file.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);
                var fileId= await _fastDFSService.UploadAsync("group1", filePath);

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
                    return Ok();
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
        public async Task<IActionResult> DownloadAsync(string fileId)
        {
            try
            {
                var fileBytes =await _fastDFSService.DownloadAsync("group1", fileId);
                var fileName = fileId + ".jpg"; // 保存文件的名称
             
                if (fileBytes!=null)
                {
                    return File(fileBytes, "application/octet-stream", fileName);
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
        public async Task<IActionResult> DeleteAsync(string fileId)
        {
            try
            {
                await _fastDFSService.DeleteAsync("group1", fileId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
