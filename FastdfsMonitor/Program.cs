using FastDFSCore;
using FastdfsMonitor.Entities;
using FastdfsMonitor.Services;
using Microsoft.EntityFrameworkCore;

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