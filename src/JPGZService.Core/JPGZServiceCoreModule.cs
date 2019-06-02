using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using JPGZService.Configuration;
using JPGZService.Localization;

namespace JPGZService
{
    public class JPGZServiceCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JPGZServiceCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            //IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
