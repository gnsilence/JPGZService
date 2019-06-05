using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.FreeSqlSqlserver.ABPFreeSql.Configuration
{
   internal class AbpFreesqlModuleConfiguration : IAbpFreesqlModuleConfiguration
    {
        public string ConnectionString { get; set; }
        public string SolveConnectionstring { get; set; }
    }
}
