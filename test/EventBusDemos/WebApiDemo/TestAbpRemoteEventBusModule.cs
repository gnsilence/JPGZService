using Abp.Grpc.Client;
using Abp.Grpc.Client.Configuration;
using Abp.Grpc.Client.Extensions;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.RemoteEventBus;
using Abp.RemoteEventBus.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo
{
    [DependsOn(typeof(AbpRemoteEventBusModule),typeof(AbpGrpcClientModule))]
    public class TestAbpRemoteEventBusModule: AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestAbpRemoteEventBusModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            // 配置grpc，直连模式
            Configuration.Modules.UseGrpcClientForDirectConnection(new[]
            {
                new GrpcServerNode
                {
                    GrpcServiceIp = "127.0.0.1",
                    GrpcServiceName = "TestServiceName",
                    GrpcServicePort = 40001
                }
            });
            // eventbus
            Configuration.Modules.RemoteEventBus().UseRedis().Configure(x =>
            {
                x.Server = "localhost";
            });
            Configuration.Modules.RemoteEventBus().AutoSubscribe();
        }
    }
}
