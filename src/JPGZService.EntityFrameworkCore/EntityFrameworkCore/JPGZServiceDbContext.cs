using Microsoft.EntityFrameworkCore;
using Abp.EntityFrameworkCore;
using JPGZService.SqlServertestModel;

namespace JPGZService.EntityFrameworkCore
{
    public class JPGZServiceDbContext : AbpDbContext
    {
        /* Define a DbSet for each entity of the application */
        public JPGZServiceDbContext(DbContextOptions<JPGZServiceDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var converter = new CastingConverter<int, decimal>();
            //modelBuilder.Entity<Evaluation>().Property(p => p.Overall).HasConversion(converter);

            //对已经删除的试题进行全局过滤
            //modelBuilder.Entity<QuestionInfo>(k =>
            //{
            //    k.HasQueryFilter(n => (n.IsDelete == 0 ? true : false));
            //});
            //modelBuilder.Entity<Video>(v =>
            //{
            //    v.HasQueryFilter(n => (n.IsDelete == 0 ? true : false));
            //});
            //modelBuilder.Entity<TrainCurriculumModel>(v =>
            //{
            //    v.HasQueryFilter(n => n.IsDelete == 0);
            //});
            //modelBuilder.Entity<ClassInfo>(c =>
            //{
            //    c.HasQueryFilter(cs => (cs.ActiveStatus == 1 && cs.IsDelete == 0)); // 班型为已经发布的,未删除的
            //});
            //modelBuilder.Entity<Teacher>(t =>
            //{
            //    t.HasQueryFilter(ts => (ts.DeleteMark == false && ts.Employstatus == 0 && ts.TrainingStatus == 0 && ts.Status == 1 && ts.CoachRole == 1 && (ts.UploadStatus == 2 || ts.UploadStatus == 3)));  // 已激活，未删除，培训状态为“正常”，在职状态为“在职”
            //});
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<News> News { get; set; }
    }
}
