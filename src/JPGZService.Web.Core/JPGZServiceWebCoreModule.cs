using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using JPGZService.Authentication.JwtBearer;
using JPGZService.Configuration;
using JPGZService.EntityFrameworkCore;
using Abp.Runtime.Caching.Redis;
using Abp.MailKit;
using ABP.FreeSqlSqlserver;
using ABP.FreeSqlSqlserver.Configuration.Startup;

#if FEATURE_SIGNALR
using Abp.Web.SignalR;
#elif FEATURE_SIGNALR_ASPNETCORE
using Abp.AspNetCore.SignalR;
#endif

namespace JPGZService
{
    [DependsOn(
         typeof(JPGZServiceApplicationModule),
         typeof(JPGZServiceEntityFrameworkModule),
         typeof(AbpAspNetCoreModule),
        typeof(AbpRedisCacheModule),
        typeof(AbpMailKitModule)
#if FEATURE_SIGNALR 
        ,typeof(AbpWebSignalRModule)
#elif FEATURE_SIGNALR_ASPNETCORE
        , typeof(AbpAspNetCoreSignalRModule)
#endif
     )]
    public class JPGZServiceWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public JPGZServiceWebCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                JPGZServiceConsts.ConnectionStringName
            );
            //禁用redis缓存会自动使用内存缓存
            if (bool.Parse(_appConfiguration["App:RedisCache:IsEnabled"]))
            {
                //使用redis作为缓存
                Configuration.Caching.UseRedis(options =>
                {
                    options.ConnectionString = _appConfiguration["App:RedisCache:ConnectionString"];
                    options.DatabaseId = _appConfiguration.GetValue<int>("App:RedisCache:DatabaseId");
                });
                //配置redis的Cache过期时间
                Configuration.Caching.Configure("mycache", cache =>
                {
                    //缓存滑动过期时间,时长应当根据数据的更新频率来设置
                    cache.DefaultSlidingExpireTime = TimeSpan.FromMinutes(10);
                });
            }
            //其他缓存时间配置
            Configuration.Caching.ConfigureAll(options =>
            {
                options.Clear();
                options.DefaultSlidingExpireTime = TimeSpan.FromMinutes(5);
            });
            //使用配置管理器
            Configuration.Settings.Providers.Add<ConfigSettingProvider>();
            // Use database for language management
            //Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(JPGZServiceApplicationModule).GetAssembly()
                 );
            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JPGZServiceWebCoreModule).GetAssembly());
        }
    }
}
