# FastdfsMonitor

## 运行结果如图:
### Fastdfs文件管理页面
![image](https://raw.githubusercontent.com/WuLex/UsefulPicture/main/fastdfsmanager/fastdfslist.png)


### Centos7.9服务器作为宿主机

docker容器

![image](https://raw.githubusercontent.com/WuLex/UsefulPicture/main/fastdfsmanager/fastdfsresult1.png)

查看服务器挂载目录(挂载宿主机目录到容器目录)

![image](https://raw.githubusercontent.com/WuLex/UsefulPicture/main/fastdfsmanager/fastdfsresult3.png)


### Fastdfs监控页面
```shell
docker exec -it storage fdfs_monitor /etc/fdfs/client.conf list group1
```

![image](https://raw.githubusercontent.com/WuLex/UsefulPicture/main/fastdfsmanager/fastdfsmonitor1.png)

![image](https://raw.githubusercontent.com/WuLex/UsefulPicture/main/fastdfsmanager/fastdfsmonitor2.png)


----------------------------------------------------

## 环境搭建命令记录
[Centos 7.9中使用Docker搭建FastDFS环境记录](https://github.com/WuLex/FastdfsMonitor/blob/main/Centos%207.9%E4%B8%AD%E4%BD%BF%E7%94%A8Docker%E6%90%AD%E5%BB%BAFastDFS%E7%8E%AF%E5%A2%83%E8%AE%B0%E5%BD%95.md)

## 常用命令记录
[命令记录](https://github.com/WuLex/FastdfsMonitor/blob/main/%E5%B8%B8%E7%94%A8%E5%91%BD%E4%BB%A4%E8%AE%B0%E5%BD%95.md)

----------------------------------------------------

## 配置加速地址

> Ubuntu 16.04+、Debian 8+、CentOS 7+

创建或修改 `/etc/docker/daemon.json`：

```bash
sudo mkdir -p /etc/docker
sudo tee /etc/docker/daemon.json <<-'EOF'
{
    "registry-mirrors": [
        "https://docker.m.daocloud.io",
        "https://dockerproxy.com",
        "https://docker.mirrors.ustc.edu.cn",
        "https://docker.nju.edu.cn"
    ]
}
EOF
sudo systemctl daemon-reload
sudo systemctl restart docker
```
