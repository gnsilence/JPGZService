using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.FreeSqlSqlserver.ABPFreeSql
{
    public static class IFreeSqlProvider
    {
        /// <summary>
        /// 获取配置信息
        /// </summary>
        private static readonly GetConfig getConfig = new GetConfig();
        /// <summary>
        /// 定义freesql
        /// </summary>
        public static IFreeSql Database = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.SqlServer, getConfig.GetConnectionstring())
            .UseAutoSyncStructure(false) //自动同步实体结构到数据库
            .UseConfigEntityFromDbFirst(true)
            //.UseSlave(getConfig.GetSolveConnectionString())//使用从库
            .Build();
    }
}
