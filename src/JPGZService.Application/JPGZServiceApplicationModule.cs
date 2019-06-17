using Abp.AutoMapper;
using Abp.Grpc.Server;
using Abp.Grpc.Server.Extensions;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JPGZService.Interceptors;
//using JPGZService.Authorization;

namespace JPGZService
{
    [DependsOn(
        typeof(JPGZServiceCoreModule), 
        typeof(AbpAutoMapperModule),
        typeof(AbpGrpcServerModule))]
    public class JPGZServiceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //配置grpc
            Configuration.Modules.UseGrpcService(option =>
            {
                option.GrpcBindAddress = "0.0.0.0";
                option.GrpcBindPort = 40001;
            }).AddRpcServiceAssembly(typeof(JPGZServiceApplicationModule).Assembly);
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
