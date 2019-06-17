using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Dependency;
using Abp.RemoteEventBus;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bootstrapper = AbpBootstrapper.Create<TestAbpRemoteEventBusModule>();


            //bootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f =>
            //   f.UseAbpLog4Net().WithConfig("log4net.config"));

            bootstrapper.Initialize();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(options =>
            {
             
            })
            .UseStartup<Startup>();
    }
}
