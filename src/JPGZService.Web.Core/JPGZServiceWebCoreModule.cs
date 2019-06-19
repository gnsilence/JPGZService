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
using Abp.Web.Api.ProxyScripting.Generators;
using Microsoft.AspNetCore.Mvc.Internal;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc;
using Abp.RemoteEventBus;
using Abp.RemoteEventBus.Redis;
using Abp.Grpc.Server;
using Abp.Grpc.Server.Extensions;

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
        typeof(AbpMailKitModule),
        typeof(AbpRemoteEventBusModule),
        typeof(AbpGrpcServerModule)
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
            //配置grpc
            Configuration.Modules.UseGrpcService(option =>
            {
                option.GrpcBindAddress = _appConfiguration["Grpc:GrpcBindAddress"];
                option.GrpcBindPort = int.Parse(_appConfiguration["Grpc:GrpcBindPort"]);
            }).AddRpcServiceAssembly(typeof(JPGZServiceApplicationModule).Assembly);

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
                 ).
                 /* 自定义路由格式，
                 默认为/api/services/app/Controller.ControllerName/action.ActionName/*/
                 ConfigureControllerModel(model =>
                 {
                     foreach (var action in model.Actions)
                     {
                         var verb = ProxyScriptingHelper.GetConventionalVerbForMethodName(action.ActionName);
                         var constraint = new HttpMethodActionConstraint(new List<string> { verb });

                         foreach (var selector in action.Selectors)
                         {
                             selector.ActionConstraints.Add(constraint);
                             selector.AttributeRouteModel = new AttributeRouteModel(
                                 new RouteAttribute(
                                     $"api/{action.Controller.ControllerName}/{action.ActionName}"
                                 )
                             );
                         }
                     }
                 }); ;
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
        public override void PostInitialize()
        {
            //配置分布式事件总线
            if (bool.Parse(_appConfiguration["App:RedisCache:IsEnabled"]))
            {

                Configuration.Modules.RemoteEventBus().UseRedis().Configure(x =>
                {
                    x.Server = _appConfiguration["App:RedisCache:ConnectionString"];
                });
            }
            //自动订阅发布的消息,必须借助于redis，或者rabbitmq
            Configuration.Modules.RemoteEventBus().AutoSubscribe();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JPGZServiceWebCoreModule).GetAssembly());
        }
    }
}
