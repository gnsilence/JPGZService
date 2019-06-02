using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.Extensions;
using JPGZService.AppConfigurtaionServices;
using JPGZService.Configuration;
using JPGZService.Identity;
using System.IO;
using System.Collections.Generic;


#if FEATURE_SIGNALR
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using Abp.Owin;
using JPGZService.Owin;
#elif FEATURE_SIGNALR_ASPNETCORE
using Abp.AspNetCore.SignalR.Hubs;
#endif

namespace JPGZService.Web.Host.Startup
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";

        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //添加系统配置
            services.Configure<ApplicationConfiguration>(_appConfiguration.GetSection("ApplicationConfiguration"));
            // MVC
            services.AddMvc(
                options => options.Filters.Add(new CorsAuthorizationFilterFactory(_defaultCorsPolicyName))
            );

            AuthConfigurer.Configure(services, _appConfiguration);
            ConfigHangfire.ConfigureHangFire(services,_appConfiguration);
#if FEATURE_SIGNALR_ASPNETCORE
            services.AddSignalR();
#endif

            // Configure CORS
            services.AddCors(
                options => options.AddPolicy(
                    _defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            _appConfiguration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                )
            );

            // Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "ABPWebApi APIService",
                    Version = "v1",
                    Description="Use For Create Api Simple and Faster",
                    Contact=new Contact
                    {
                        Name="gnsilence",
                        Email="592254126@qq.com",
                        Url=""
                    },
                    License=new License
                    {
                        Name= "License",
                        Url=""
                    }
                });
                options.DocInclusionPredicate((docName, description) => true);

                // Define the oauth2 scheme that's in use
                options.AddSecurityDefinition("oauth2", new OAuth2Scheme()
                {
                   Flow= "implicit",//只需通过浏览器获取令牌（适用于swagger）
                   AuthorizationUrl= "http://47.105.185.242:5001/connect/authorize",
                   Description="",
                   Scopes = new Dictionary<string, string>
                    {
                        { "apitest", "APITEST - full access" }//指定客户端请求的api作用域。 如果为空，则客户端无法访问
                    }
                });
                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                var xmlPath = Path.Combine(basePath, "JPGZService.Application.xml");
                options.IncludeXmlComments(xmlPath);
                // Assign scope requirements to operations based on AuthorizeAttribute
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            //Configure Abp and Dependency Injection
            return services.AddAbp<JPGZServiceWebHostModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
            //return services.AddAbp<JPGZServiceWebHostModule>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(options => { options.UseAbpRequestLocalization = false; }); // Initializes ABP framework.

            app.UseCors(_defaultCorsPolicyName); // Enable CORS!

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAbpRequestLocalization();
            // config hangfire use httpjob
            ConfigHangfire.UseHangfireSettings(app,env,loggerFactory);

#if FEATURE_SIGNALR
            // Integrate with OWIN
            app.UseAppBuilder(ConfigureOwinServices);
#elif FEATURE_SIGNALR_ASPNETCORE
            app.UseSignalR(routes =>
            {
                routes.MapHub<AbpCommonHub>("/signalr");
            });
#endif

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                options.InjectJavascript("/swagger/ui/abp.js");
                options.InjectJavascript("/swagger/ui/on-complete.js");
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ABPService API V1");
            }); // URL: /swagger
        }

#if FEATURE_SIGNALR
        private static void ConfigureOwinServices(IAppBuilder app)
        {
            app.Properties["host.AppName"] = "JPGZService";

            app.UseAbp();
            
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    EnableJSONP = true
                };
                map.RunSignalR(hubConfiguration);
            });
        }
#endif
    }
}
