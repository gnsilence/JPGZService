using Abp.AutoMapper;
using Abp.Grpc.Server;
using Abp.Grpc.Server.Extensions;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JPGZService.Interceptors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
//using JPGZService.Authorization;

namespace JPGZService
{
    [DependsOn(
        typeof(JPGZServiceCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class JPGZServiceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Configuration.Authorization.Providers.Add<JPGZServiceAuthorizationProvider>();
            ServiceInterceptorRegistrar.Initialize(IocManager);
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
