using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JPGZService.Configuration;

namespace JPGZService.Web.Host.Startup
{
    [DependsOn(
       typeof(JPGZServiceWebCoreModule))]
    public class JPGZServiceWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public JPGZServiceWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JPGZServiceWebHostModule).GetAssembly());
        }
    }
}
