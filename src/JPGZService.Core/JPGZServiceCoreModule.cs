using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using JPGZService.Authorization.Roles;
using JPGZService.Authorization.Users;
using JPGZService.Configuration;
using JPGZService.Localization;
using JPGZService.MultiTenancy;
using JPGZService.Timing;

namespace JPGZService
{
    public class JPGZServiceCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            //Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            //Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            //Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            //JPGZServiceLocalizationConfigurer.Configure(Configuration.Localization);

            //// Enable this line to create a multi-tenant application.
            //Configuration.MultiTenancy.IsEnabled = JPGZServiceConsts.MultiTenancyEnabled;

            //// Configure roles
            //AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JPGZServiceCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
