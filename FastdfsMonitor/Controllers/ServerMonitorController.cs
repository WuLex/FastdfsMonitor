using FastdfsMonitor.Models;
using FastdfsMonitor.Utils;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System.Collections.Generic;
using System.Net.Sockets;

namespace FastdfsMonitor.Controllers
{
    public class ServerMonitorController : Controller
    {
        private readonly ISshClientWrapper _sshClientWrapper;
        private readonly IConfiguration _configuration;


        public ServerMonitorController(ISshClientWrapper sshClientWrapper, IConfiguration configuration)
        {
            _sshClientWrapper = sshClientWrapper;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region 方式一
        /// <summary>
        /// 执行命令方式一
        /// </summary>
        /// <returns></returns>
        //public IActionResult ExecuteDockerCommand()
        //{
        //    // 服务器连接信息
        //    string host = "centos_host";
        //    int port = 22;
        //    string username = "centos_username";
        //    string password = "centos_password";
        //    // Docker容器名称
        //    string containerName = "container_name";
        //    // Docker命令和参数
        //    string dockerCommand = $"docker exec {containerName} fdfs_monitor <tracker_ip>:<tracker_port>";

        //    // 创建SSH连接
        //    using (var client = new SshClient(host, port, username, password))
        //    {
        //        client.Connect();
        //        if (client.IsConnected)
        //        {
        //            // 执行Docker命令
        //            var command = client.CreateCommand(dockerCommand);
        //            string output = command.Execute();
        //            int exitCode = command.ExitStatus;

        //            // 构造DockerExecResponse对象
        //            var response = new DockerExecResponse
        //            {
        //                Output = output,
        //                ExitCode = exitCode
        //            };

        //            client.Disconnect();

        //            // 将响应参数传递给视图
        //            return View(response);
        //        }
        //        else
        //        {
        //            // 连接失败处理
        //            return Content("Failed to connect to CentOS server.");
        //        }
        //    }
        //} 
        #endregion

        /// <summary>
        /// 执行命令方式二
        /// </summary>
        /// <returns></returns>
        public IActionResult ExecuteMonitorCommand()
        {
            // Docker容器名称
            string containerName = "trakcer";

            string groupName = _configuration["FastDFS:DefaultStorage:Group"];

            // Docker命令和参数
            //string dockerCommand = $"docker exec {containerName} fdfs_monitor <tracker_ip>:<tracker_port>";
            //$"sudo docker exec -it {containerName} fdfs_monitor /etc/fdfs/client.conf list {groupName}";
            string dockerCommand = $"sudo docker exec {containerName} fdfs_monitor /etc/fdfs/client.conf list {groupName}";
            //dockerCommand = $"ip addr";
           
            
            // 创建SSH连接
            var client = _sshClientWrapper.GetSshClient();
           
            client.Connect();
            if (client.IsConnected)
            {
                //var sshcommand=client.RunCommand(dockerCommand);
                //var result = sshcommand.Result;

                // 执行Docker命令
                var command = client.CreateCommand(dockerCommand);
                string output = command.Execute();
                int exitCode = command.ExitStatus;


                //TimeSpan
                //构造DockerExecResponse对象
                var response = new DockerExecResponse
                {
                    Output = output,
                    ExitCode = exitCode,
                    Error = command.Error,
                    CommandTimeout = command.CommandTimeout.TotalSeconds
                };

                client.Disconnect();
                // 将响应参数传递给视图
                return View(response);
            }
            else
            {
                // 连接失败处理
                return Content("无法连接到 CentOS 服务器");
            }


            #region using后下次调用会异常
            //using (var client = _sshClientWrapper.GetSshClient())
            //{
            //    client.Connect();
            //    if (client.IsConnected)
            //    {
            //        // 执行Docker命令
            //        var command = client.CreateCommand(dockerCommand);
            //        string output = command.Execute();
            //        int exitCode = command.ExitStatus;

            //        // 构造DockerExecResponse对象
            //        var response = new DockerExecResponse
            //        {
            //            Output = output,
            //            ExitCode = exitCode
            //        };

            //        client.Disconnect();
            //        // 将响应参数传递给视图
            //        return View(response);
            //    }
            //    else
            //    {
            //        // 连接失败处理
            //        return Content("Failed to connect to CentOS server.");
            //    }

            //} 
            #endregion
        }
    }
}
