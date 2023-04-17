using FastDFSCore;
using FastDFSCore.Protocols;
using FastdfsMonitor.Entities;
using FastdfsMonitor.Models;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Net;

namespace FastdfsMonitor.Services
{
    #region MyRegion
    //public class FastDFSServiceold
    //{
    //    private readonly IConfiguration _configuration;

    //    public FastDFSServiceold(IConfiguration configuration)
    //    {
    //        _configuration = configuration;
    //        var trackerServers = new List<IPEndPoint>
    //        {
    //            new IPEndPoint(
    //                IPAddress.Parse(_configuration["FastDFS.TrackerServer"].Split(':')[0]),
    //                int.Parse(_configuration["FastDFS.TrackerServer"].Split(':')[1]))
    //        };
    //        ClientGlobal.Init(new FastDFSGlobalConfig()
    //        {
    //            TrackerServers = trackerServers,
    //            GZipEnable = true
    //        });
    //    }

    //    public void Upload(string groupName, string filePath)
    //    {
    //        var storageNode = GetStorageNode(groupName);
    //        using var stream = new FileStream(filePath, FileMode.Open);
    //        var fileBuffer = new byte[stream.Length];
    //        stream.Read(fileBuffer, 0, fileBuffer.Length);
    //        var fileExtName = Path.GetExtension(filePath);
    //        var fileInfo = new NameValuePair[]
    //        {
    //            new NameValuePair("FileName", Path.GetFileNameWithoutExtension(filePath)),
    //            new NameValuePair("FileSize", stream.Length.ToString())
    //        };
    //        var fileId = StorageClient.UploadFile(storageNode, groupName, fileBuffer, fileExtName, fileInfo);
    //    }

    //    public byte[] Download(string groupName, string fileId)
    //    {
    //        var storageNode = GetStorageNode(groupName, fileId);
    //        return StorageClient.DownloadFile(storageNode, groupName, fileId);
    //    }

    //    public void Delete(string groupName, string fileId)
    //    {
    //        var storageNode = GetStorageNode(groupName, fileId);
    //        StorageClient.DeleteFile(storageNode, groupName, fileId);
    //    }

    //    private StorageNode GetStorageNode(string groupName, string fileId = null)
    //    {
    //        var trackerClient = new TrackerClient();
    //        var trackerServer = trackerClient.GetTrackerServer();
    //        var storageServer = fileId != null
    //            ? trackerClient.GetFetchStorage(trackerServer, groupName, fileId)
    //            : trackerClient.GetStorageServer(trackerServer, groupName);
    //        return new StorageNode(storageServer.EndPoint, storageServer.StorePathIndex);
    //    }
    //} 
    #endregion

    public class FastDFSService: IFastDFSService
    {
        private readonly FastDFSOptions _options;
        private readonly IFastDFSClient _client;
    
        public FastDFSService(IOptions<FastDFSOptions> optionsAccessor, IFastDFSClient client)
        {
            
            _options = optionsAccessor.Value;
            _client = client;


        }
      

        public async Task<string> UploadAsync(string groupName, string filePath)
        {
            var storageNode = await _client.GetStorageNodeAsync(groupName);
            return await _client.UploadFileAsync(storageNode,filePath); 
        }

        public async Task<string> GetffffAsync(string groupName, string filePath)
        {
            var storageNode = await _client.GetStorageNodeAsync(groupName);
            return await _client.UploadFileAsync(storageNode, filePath);
        }
        //https://github.com/cocosip/FastDFSCore/blob/master/samples/FastDFSCore.Sample/ISampleAppService.cs
        //https://github.com/cocosip/FastDFSCore/blob/master/samples/FastDFSCore.Sample/SampleAppService.cs
        public async Task<byte[]> DownloadAsync(string groupName, string fileId)
        {
            var storageNode = await _client.GetStorageNodeAsync(groupName);
            return await _client.DownloadFileAsync(storageNode, fileId);
        }

        public async Task<bool> DeleteAsync(string groupName, string fileId)
        {
            return await _client.RemoveFileAsync(groupName, fileId);
        } 
      
    }
}
