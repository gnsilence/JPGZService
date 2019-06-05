using Abp.Configuration.Startup;
using ABP.FreeSqlSqlserver.ABPFreeSql.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.FreeSqlSqlserver.Configuration.Startup
{
  public static class AbpFreesqlConfigurationExtensions
    {
        public static IAbpFreesqlModuleConfiguration AbpFreeSql(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.GetOrCreate("Modules.AbpFreesqlModule", () => configurations.AbpConfiguration.IocManager.Resolve<IAbpFreesqlModuleConfiguration>());
        }
    }
}
