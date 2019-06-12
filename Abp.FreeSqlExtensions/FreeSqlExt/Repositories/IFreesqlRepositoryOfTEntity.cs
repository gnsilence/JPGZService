using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.FreeSqlExtensions.FreeSqlExt.Repositories
{
    public interface IFreeSqlRepository<TEntity> : IFreeSqlRepository<TEntity, int> where TEntity : class, IEntity<int>
    {
    }
}
