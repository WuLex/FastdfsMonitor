using FastDFSCore;
using FastdfsMonitor.Entities;
using FastdfsMonitor.Models;
using FastdfsMonitor.Services;
using FastdfsMonitor.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IFastDFSService, FastDFSService>();
var Configuration = builder.Configuration;

#region �������ݿ�
builder.Services.AddDbContext<RocketDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("RocketDbConnectionString")));
#endregion
#region ֱ��ע��FastDFSCore
//���FastDFS��json�������ݣ�
builder.Services.Configure<FastDFSOptions>(Configuration.GetSection("FastDFS"));
//ʹ���� AddSingleton ������ע�� FastDFSService ����Ϊ���������Ա�������Ӧ�ó����й���һ�� FastDFSClient ����
builder.Services.AddFastDFSCore(c =>
{
    c.ClusterConfigurations.Add(new ClusterConfiguration()
    {
        Name = "Cluster1",
        Trackers = new List<Tracker>()
                       { 
                        new Tracker("192.168.233.223", 22122)
                       }
    });
})
 .AddFastDFSDotNetty(); //ͨ�ŷ�ʽһ
                        //.AddFastDFSSuperSocket(); //ͨ�ŷ�ʽ��
#endregion


#region ע��ISshClientWrapper
builder.Services.AddSingleton<ISshClientWrapper>(sp =>
{
    // ��ȡSshSettings����
    var sshSettings = Configuration.GetSection("SshSettings").Get<SshSettings>();

    #region ��ȡ���÷�ʽһ
    //var host = Configuration["SshSettings:Host"];
    //var port = int.Parse(Configuration["SshSettings:Port"]);
    //var username = Configuration["SshSettings:Username"];
    //var password = Configuration["SshSettings:Password"];
    //return new SshClientWrapper(host, port, username, password);
    #endregion

    #region ��ȡ���÷�ʽ��
    return new SshClientWrapper(sshSettings.Host, sshSettings.Port, sshSettings.Username, sshSettings.Password);
    #endregion
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();