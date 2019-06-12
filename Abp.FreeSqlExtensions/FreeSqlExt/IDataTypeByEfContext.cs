using FreeSql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.FreeSqlExtensions.FreeSqlExt
{
   public interface IDataTypeByEfContext
    {
        DataType GetDbType(string contextname);
    }
}
