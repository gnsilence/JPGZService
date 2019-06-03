using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.HttpJob;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace JPGZService.Web.Host.Startup
{
    public static class ConfigHangfire
    {
        #region Properties
        /// <summary>
        /// 使用redis缓存
        /// </summary>
        static ConnectionMultiplexer Redis;
        /// <summary>
        /// 是否启用hangfire
        /// </summary>
        private static bool IsEnabled { get; set; }
        /// <summary>
        /// 是否只读面板
        /// </summary>
        private static bool IsReadOnly { get; set; }
        /// <summary>
        /// 返回跳转的链接
        /// </summary>
        private static string BackLink { get; set; }
        /// <summary>
        /// 队列名称集合
        /// </summary>
        private static string[] Queues { get; set; }
        /// <summary>
        /// 管理员账号
        /// </summary>
        private static string Account { get; set; }
        /// <summary>
        /// 管理员密码
        /// </summary>
        private static string Password { get; set; }
        /// <summary>
        /// hangfire存储库地址
        /// </summary>
        private static string ConnectionStrng { get; set; }
        #endregion

        /// config hangfire
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureHangFire(IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                var listqueue = new List<string>();
                IsEnabled = bool.Parse(configuration["Hangfire:IsEnabled"]);
                IsReadOnly = bool.Parse(configuration["Hangfire:IsReadOnly"]);
                BackLink = configuration["Hangfire:BackLink"].ToString();
                configuration.GetSection("Hangfire:Queues").Bind(listqueue);
                Queues = listqueue.Any() ? listqueue.ToArray<string>():default;
                Account= configuration["Hangfire:AdminAccount"].ToString();
                Password= configuration["Hangfire:AdminPassword"].ToString();
                ConnectionStrng= configuration["Hangfire:ConnectionStrng"].ToString();

                if (IsEnabled)
                {
                    Redis = ConnectionMultiplexer.Connect(ConnectionStrng);
                    services.AddHangfire(config =>
                    {
                        //使用redis
                        config.UseRedisStorage(Redis, new Hangfire.Redis.RedisStorageOptions()
                        {
                            FetchTimeout = TimeSpan.FromMinutes(5),
                            Prefix = "{hangfire}:",
                            //活动服务器超时时间
                            InvisibilityTimeout = TimeSpan.FromHours(1),
                            //任务过期检查频率
                            ExpiryCheckInterval = TimeSpan.FromHours(1),
                            DeletedListSize = 10000,
                            SucceededListSize = 10000
                        })

                        .UseHangfireHttpJob(new HangfireHttpJobOptions()
                        {
                            AddHttpJobButtonName = "添加计划任务",
                            AddRecurringJobHttpJobButtonName = "添加定时任务",
                            EditRecurringJobButtonName = "编辑定时任务",
                            PauseJobButtonName = "暂停或开始",
                            DashboardTitle = "XXX公司任务管理",
                            DashboardName = "后台任务管理",
                            DashboardFooter = "XXX公司后台任务管理V1.0.0.0"
                        })
                        .UseConsole(new ConsoleOptions()
                        {
                            BackgroundColor = "#000079"
                        })
                        .UseDashboardMetric(DashboardMetrics.AwaitingCount)
                        .UseDashboardMetric(DashboardMetrics.ProcessingCount)
                        .UseDashboardMetric(DashboardMetrics.RecurringJobCount)
                        .UseDashboardMetric(DashboardMetrics.RetriesCount)
                        .UseDashboardMetric(DashboardMetrics.FailedCount);
                    });
                }

            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// config hangfire
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public static void UseHangfireSettings(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            try
            {
                if (IsEnabled)
                {

                    // 设置语言
                    var supportedCultures = new[]
                    {
                        new CultureInfo("zh-CN"),
                        new CultureInfo("en-US")
                    };
                    app.UseRequestLocalization(new RequestLocalizationOptions
                    {
                        DefaultRequestCulture = new RequestCulture("zh-CN"),
                        // Formatting numbers, dates, etc.
                        SupportedCultures = supportedCultures,
                        // UI strings that we have localized.
                        SupportedUICultures = supportedCultures
                    });

                    app.UseHangfireServer(new BackgroundJobServerOptions()
                    {
                        ServerTimeout = TimeSpan.FromMinutes(4),
                        SchedulePollingInterval = TimeSpan.FromSeconds(1),// 秒级任务需要配置短点，一般任务可以配置默认时间，默认15秒
                        ShutdownTimeout = TimeSpan.FromMinutes(30),// 超时时间
                        Queues = Queues,// 队列
                        WorkerCount = Math.Max(Environment.ProcessorCount, 40)// 工作线程数，当前允许的最大线程，默认20
                    }
                    );
                    app.UseHangfireDashboard("/job", new DashboardOptions
                    {
                        AppPath = BackLink,// 返回时跳转的地址
                        DisplayStorageConnectionString = false,// 是否显示数据库连接信息
                        IsReadOnlyFunc = Context =>
                        {
                            var isreadonly = IsReadOnly;
                            return isreadonly;
                        },
                        Authorization = new[] { new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                        {
                            RequireSsl = false,// 是否启用ssl验证，即https
                            SslRedirect = false,
                            LoginCaseSensitive = true,
                            Users = new []
                            {
                                new BasicAuthAuthorizationUser
                                {
                                    Login =Account,// 登录账号
                                    PasswordClear =  Password// 登录密码
                                }
                            }
                        })
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                loggerFactory.CreateLogger("HangfireStartUpError").Log(LogLevel.Error, ex.ToString());
            }
        }
    }
}
