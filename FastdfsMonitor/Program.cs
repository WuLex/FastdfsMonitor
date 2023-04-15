using FastDFSCore;
using FastdfsMonitor.Entities;
using FastdfsMonitor.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var Configuration = builder.Configuration;

#region 配置数据库
builder.Services.AddDbContext<RocketDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("RocketDbConnectionString")));
#endregion
#region 直接注入
//添加FastDFS的json配置数据，
//builder.Services.Configure<FastDFSOptions>(Configuration.GetSection("FastDFS"));
//使用了 AddSingleton 方法来注册 FastDFSService 类作为单例服务，以便在整个应用程序中共享一个 FastDFSClient 对象。
builder.Services.AddSingleton<IFastDFSService, FastDFSService>();

builder.Services.AddFastDFSCore(c =>
{
    c.ClusterConfigurations.Add(new ClusterConfiguration()
    {
        Name = "Cluster1",
        Trackers = new List<Tracker>()
                       {
                        new Tracker("192.168.0.102", 22122)
                       }
    });
});
builder.Services.AddFastDFSCore(c =>
{
    c.ClusterConfigurations.Add(new ClusterConfiguration()
    {
        Name = "Cluster1",
        Trackers = new List<Tracker>()
                       {
                        new Tracker("192.168.0.102", 22122)
                       }
    });
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