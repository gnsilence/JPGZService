using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.FreeSqlSqlserver.ABPFreeSql.Configuration
{
   public interface IAbpFreesqlModuleConfiguration
    {
        string ConnectionString { get; set; }
        /// <summary>
        /// 使用从库
        /// </summary>
        string SolveConnectionstring { get; set; }
    }
}
