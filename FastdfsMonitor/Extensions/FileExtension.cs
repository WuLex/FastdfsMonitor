namespace FastdfsMonitor.Extensions
{
    public static class FileExtension
    {
        /// <summary>
        /// 将文件大小转换为 MB
        /// </summary>
        /// <param name="fileSizeInBytes"></param>
        /// <returns></returns>
        public static double ToMb(this long fileSizeInBytes)
        {
            return (double)fileSizeInBytes / (1024 * 1024);
        }

        /// <summary>
        /// 获取某个路径中文件的扩展名
        /// </summary>
        public static string GetPathExtension(this string path)
        {
            if (path != "" && path.IndexOf('.') >= 0)
            {
                return path.Substring(path.LastIndexOf('.'));
            }
            return "";
        }
    }
}
