using Abp;
using Abp.Modules;
using ABP.FreeSqlSqlserver.ABPFreeSql.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ABP.FreeSqlSqlserver.ABPFreeSql
{
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpFreesqlModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<IAbpFreesqlModuleConfiguration, AbpFreesqlModuleConfiguration>();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
