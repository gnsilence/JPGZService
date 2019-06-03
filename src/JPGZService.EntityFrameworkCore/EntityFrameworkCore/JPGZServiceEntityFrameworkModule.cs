using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace JPGZService.EntityFrameworkCore
{
    [DependsOn(
        typeof(JPGZServiceCoreModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class JPGZServiceEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        // SkipRegister SqlserverContext
        public bool SkipSqlserverDbContextRegistration { get; set; } = false;
        /// <summary>
        /// SkipRegister MysqlContext
        /// </summary>
        public bool SkipMysqlDbContextRegistration { get; set; }
        /// <summary>
        /// Skip postSqlContext
        /// </summary>
        public bool SkipPostgreSqlDbContextRegistration { get; set; }
        /// <summary>
        /// skip seed initdata
        /// </summary>
        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            Configuration.ReplaceService<IConnectionStringResolver, MyConnectionStringResolver>();

            if (!SkipDbContextRegistration)
            {
                if (!SkipSqlserverDbContextRegistration)
                {
                    Configuration.Modules.AbpEfCore().AddDbContext<JPGZServiceDbContext>(options =>
                    {
                        if (options.ExistingConnection != null)
                        {
                            JPGZServiceDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                        }
                        else
                        {
                            JPGZServiceDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                        }
                    });
                }
                if (!SkipMysqlDbContextRegistration)
                {
                    //配置mysql数据库
                    Configuration.Modules.AbpEfCore().AddDbContext<JPGZServiceMysqlDbContext>(options =>
                    {
                        if (options.ExistingConnection != null)
                        {
                            JPGZServiceMysqlDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                        }
                        else
                        {
                            JPGZServiceMysqlDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                        }
                    });
                }

                if (!SkipPostgreSqlDbContextRegistration)
                {
                    //配置PostgreSql数据库
                    Configuration.Modules.AbpEfCore().AddDbContext<JPGZServicePostgreSqlDbContext>(options =>
                    {
                        if (options.ExistingConnection != null)
                        {
                            JPGZServicePostgreSqlDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                        }
                        else
                        {
                            JPGZServicePostgreSqlDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                        }
                    });
                } 
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JPGZServiceEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                //SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
