using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABP.FreeSqlSqlserver.ABPFreeSql
{
    /// <summary>
    /// 拓展接口，继承此接口可以额外使用freesql所有功能，需要自己添加接口方法，不继承默重写IRepository自带的方法
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IFreeSqlRepository<TEntity> where TEntity : class
    {
        TEntity GetEntityBySql();
    }
}
