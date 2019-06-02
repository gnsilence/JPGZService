using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JPGZService.Authorization;

namespace JPGZService
{
    [DependsOn(
        typeof(JPGZServiceCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class JPGZServiceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<JPGZServiceAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(JPGZServiceApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
