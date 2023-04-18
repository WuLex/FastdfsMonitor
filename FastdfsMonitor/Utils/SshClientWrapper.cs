using Renci.SshNet;
using ConnectionInfo = Renci.SshNet.ConnectionInfo;

namespace FastdfsMonitor.Utils
{
    public class SshClientWrapper : ISshClientWrapper
    {
        private readonly SshClient _sshClient;

        public SshClientWrapper(string host, int port, string username, string password)
        {
            var connectionInfo = new ConnectionInfo(host, port, username, new PasswordAuthenticationMethod(username, password));
            _sshClient = new SshClient(connectionInfo);
        }
        public SshClient GetSshClient()
        {
            return _sshClient;
        }
    }
}
