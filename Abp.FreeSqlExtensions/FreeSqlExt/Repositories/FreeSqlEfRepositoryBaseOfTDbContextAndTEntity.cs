using Abp.Data;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.FreeSqlExtensions.FreeSqlExt.Repositories
{
    public class FreeSqlEfRepositoryBase<TDbContext, TEntity> : FreeSqlEfRepositoryBase<TDbContext, TEntity, int>, IFreeSqlRepository<TEntity>
           where TEntity : class, IEntity<int>
          where TDbContext : class
    {
        public FreeSqlEfRepositoryBase(IActiveTransactionProvider activeTransactionProvider,IDataTypeByEfContext dataTypeByEfContext) : base(activeTransactionProvider, dataTypeByEfContext)
        {

        }
    }
}
