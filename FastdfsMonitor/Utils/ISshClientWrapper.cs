using Renci.SshNet;

namespace FastdfsMonitor.Utils
{
    public interface ISshClientWrapper
    {
        SshClient GetSshClient();
    }
}
