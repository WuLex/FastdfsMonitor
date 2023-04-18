namespace FastdfsMonitor.Models
{
    public class DockerExecResponse
    {
        public string Output { get; set; }
        public int ExitCode { get; set; }

        /// <summary>
        /// 获取命令执行错误
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// 获取或设置命令超时,单位:秒
        /// </summary>
        public double CommandTimeout { get; set; }
    }
}
