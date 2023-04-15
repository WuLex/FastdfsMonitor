using FastDFSCore.Protocols;
using Microsoft.EntityFrameworkCore;

namespace FastdfsMonitor.Entities
{
    public class RocketDbContext:DbContext
    {
        public RocketDbContext(DbContextOptions<RocketDbContext> options) : base(options)
        {
        }

        public DbSet<FastdfsFileInfo> FastDFSFileInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 配置实体类与表名的映射关系
            modelBuilder.Entity<FastdfsFileInfo>().ToTable("FastdfsFileInfo");
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //
        //    // 配置数据库连接字符串(Program中已配置,就无需在此配置)
        //    optionsBuilder.UseSqlServer("RocketDbConnectionString");
        //}
    }
}
