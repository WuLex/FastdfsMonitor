namespace FastdfsMonitor.Services
{
    public interface IFastDFSService
    {
        Task<string> UploadAsync(string groupName, string fileExt);
        Task<bool> DeleteAsync(string groupName, string fileId);
       
        //Task<Stream> DownloadAsync(string fileId);

        Task<byte[]> DownloadAsync(string groupName, string fileId);
    }
}
