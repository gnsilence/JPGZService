using Abp.Dependency;
using ABP.FreeSqlSqlserver.ABPFreeSql.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.FreeSqlSqlserver.ABPFreeSql
{
   public class GetConfig: ITransientDependency
    {
        /// <summary>
        /// 从注入中获取配置信息
        /// </summary>
        private readonly IAbpFreesqlModuleConfiguration _configuration = IocManager.Instance.Resolve<IAbpFreesqlModuleConfiguration>();
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public string GetConnectionstring()
        {
            return _configuration.ConnectionString;
        }
        /// <summary>
        /// 获取从库连接
        /// </summary>
        /// <returns></returns>
        public string GetSolveConnectionString()
        {
            return _configuration.SolveConnectionstring;
        }
    }
}
