## Centos 7.9安装必要的软件
安装必要的软件:`yum -y install zlib zlib-devel pcre pcre-devel gcc gcc-c++ openssl openssl-devel libevent libevent-devel perl unzip net-tools wget`

```bash
docker search fastdfs
```

```bash
docker pull season/fastdfs:1.2

```

进入`storage`,配置`nginx`，在`/usr/local/nginx`目录下，修改`nginx.conf`文件,默认配置不修改也可以
```shell
docker exec -it 551473f9bcd0 /bin/bash
```
## 运行`tracker`容器
```shell
docker run -ti -d --name trakcer --restart=always -v /data/fastdfs/tracker/tracker_data:/fastdfs/tracker/data -p 22122:22122 season/fastdfs:1.2 tracker
```
## 运行`storage`容器
`--network=host`使用宿主机网络,不需要 `-p 23000:23000` 端口映射,这样传图时候就不会出现获取`storage`容器的ip问题
```shell
docker run -tid --name storage --network=host  --restart=always -e TRACKER_SERVER:192.168.233.223:22122 -v /data/fastdfs/storage/storage_data:/fastdfs/storage/data -v /data/fastdfs/storage/store_path:/fastdfs/store_path -e GROUP_NAME=group1 season/fastdfs:1.2 storage
```
## 修改`storage`容器中配置`TRACKER_SERVER=Tracker`的ip地址:`22122`
把容器中配置拷贝到宿主机
```shell
docker cp storage:/etc/nginx/conf/nginx.conf /data/fastdfs/nginx
```
修改nginx配置
```shell
vi /data/fastdfs/nginx/nginx.conf
```

修改此部分
```shell
location / {
	root /fastdfs/store_path/data;
	ngx_fastdfs_module;
}
```
把在宿主机中修改的`nginx`配置重新拷回到storage容器中
```shell
docker cp /data/fastdfs/nginx/nginx.conf  storage:/etc/nginx/conf/nginx.conf
```
## 运行`fastdfs_nginx`容器
```shell
docker run -id --name fastdfs_nginx --restart=always -v /data/fastdfs/storage/store_path:/fastdfs/store_path -v /data/fastdfs/nginx/nginx.conf:/etc/nginx/conf/nginx.conf -p 8888:80  -e TRACKER_SERVER=192.168.233.223:22122 season/fastdfs:1.2 nginx
```
## 进入tracker容器中
```shell
docker exec -it tracker bash
```
跳转`tracker`容器里的目录
```shell
cd /fastdfs/tracker/data
```
## 命令行上传文件
```shell
fdfs_upload_file /etc/fdfs/client.conf LoraKorean.jpg
```
返回地址
```shell
http://192.168.233.223:8888/group1/M00/00/00/wKjp32Q8w-aAUTsQAAElycHNJtk608.jpg
```

先把 tracker 容器中的 `client.conf` 文件复制出来
```powershell
docker cp tracker:/etc/fdfs/client.conf  /data/fastdfs/tracker
```

#修改为LInux宿主机的IP地址

```powershell
tracker_server=192.168.233.223:22122
```

#修改之后再放回到 Docker 中

```powershell
docker cp /data/fastdfs/tracker/client.conf   tracker:/etc/fdfs/client.conf  
```


#把`storage`容器中配置拷贝到宿主机

```shell
docker cp storage:/fdfs_conf/storage.conf /data/fastdfs/storage
```

```shell
tracker_server=192.168.233.223:22122
```

#宿主机中修改配置后拷贝到storage容器中

```shell
docker cp /data/fastdfs/storage/storage.conf   storage:/fdfs_conf/storage.conf 
```

#进入tracker容器中

```shell
docker exec -it 8e4f51c18b8e bash
```

#监控

```shell
fdfs_monitor /fdfs_conf/storage.conf
```

## 配置`iptables`
通过iptables的转发功能，比如，数据达到`172.17.0.2`的22122端口记录的源地址是`172.17.0.1`，我们只需要修改iptables的NAT表规则，所有转发到`172.12.0.2:22122`的数据，源地址修改为宿主主机的地址：`192.168.1.98`，这样`storage`注册到`tracker server`时，`tracker server`获取到storage的ip地址为`192.168.1.88` 而不是网关地址`172.17.0.1`。

```shell
iptables -t nat -A POSTROUTING -p tcp -m tcp --dport 22122 -d 172.17.0.3 -j SNAT --to 192.168.233.223
```

```shell
iptables -t nat -A POSTROUTING -s 172.17.0.3  -d 172.17.0.2 -p tcp -m tcp --dport 22122 -j SNAT --to-source 192.168.233.223
```

使用`iptables -L -t nat` 查看`nat`表规则

## docker网络映射
如果是Linux操作系统，还可以在启动docker容器时使用`–network=host`来进行映射。启动示例如下：
```shell
docker run -d --network=host --name tracker -v /Users/zzs/develop/temp/tracker:/var/fdfs delron/fastdfs tracker
```