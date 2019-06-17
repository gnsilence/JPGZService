using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.RemoteEventBus;
using Abp.RemoteEventBus.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDemo
{
    [DependsOn(typeof(AbpRemoteEventBusModule))]
    public class TestRemoteEventBusModule: AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestRemoteEventBusModule).GetAssembly());
        }
        public override void PostInitialize()
        {
            Configuration.Modules.RemoteEventBus().UseRedis().Configure(x =>
            {
                x.Server = "localhost";
            });
            Configuration.Modules.RemoteEventBus().AutoSubscribe();
        }
    }
}
