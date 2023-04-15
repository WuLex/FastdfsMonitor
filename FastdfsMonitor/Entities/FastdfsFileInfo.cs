namespace FastdfsMonitor.Entities
{
    public class FastdfsFileInfo
    {
        public int Id { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
        public DateTime UploadTime { get; set; }
    }
}
