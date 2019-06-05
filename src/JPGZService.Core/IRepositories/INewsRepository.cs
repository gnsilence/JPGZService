using Abp.Domain.Repositories;
using ABP.FreeSqlSqlserver.ABPFreeSql;
using JPGZService.SqlServertestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.IRepositories
{
    /// <summary>
    /// 继承IRepository为默认的所有orm都支持，继承IFreeSqlRepository，则可以额外实现freesql的方法
    /// </summary>
    public interface INewsRepository: IRepository<News,int>, IFreeSqlRepository<News>
    {

    }
}
