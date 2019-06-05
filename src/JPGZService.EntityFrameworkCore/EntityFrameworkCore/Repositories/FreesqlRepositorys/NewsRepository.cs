using ABP.FreeSqlSqlserver.ABPFreeSql;
using ABP.FreeSqlSqlserver.ABPFreeSql.Repositories;
using JPGZService.IRepositories;
using JPGZService.SqlServertestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.EntityFrameworkCore.Repositories.FreesqlRepositorys
{
    public class NewsRepository : FreeSqlRepositoryBase<News,int>, INewsRepository
    {
    }
}
