using Abp.Data;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.FreeSqlExtensions.FreeSqlExt.Repositories
{
  public  class FreeSqlRepositoryBase<TEntity> : FreeSqlRepositoryBase<TEntity, int>, IFreeSqlRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public FreeSqlRepositoryBase(IActiveTransactionProvider activeTransactionProvider,IDataTypeByEfContext dataTypeByEfContext) : base(activeTransactionProvider
            , dataTypeByEfContext)
        {

        }
    }
}
