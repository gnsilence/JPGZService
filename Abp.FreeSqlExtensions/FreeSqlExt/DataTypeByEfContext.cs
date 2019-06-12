using FreeSql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.FreeSqlExtensions.FreeSqlExt
{
    public class DataTypeByEfContext : IDataTypeByEfContext
    {
        public DataType GetDbType(string contextname)
        {
            if (contextname.ToLower().Contains("entityframeworkcore"))
            {
                if (contextname.ToLower().Contains("mysql"))
                {
                    return DataType.MySql;
                }
                if (contextname.ToLower().Contains("postgresql"))
                {
                    return DataType.PostgreSQL;
                }
                return DataType.SqlServer;
            }
            return DataType.SqlServer;
        }
    }
}
