using Abp.FreeSqlExtensions.FreeSqlExt.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.FreeSqlExtensions.FreeSqlExt
{
  public  class EfBasedFreeSqlAutoRepositoryTypes
    {
        static EfBasedFreeSqlAutoRepositoryTypes()
        {
            Default = new FreeSqlAutoRepositoryTypeAttribute(
                typeof(IFreeSqlRepository<>),
                typeof(IFreeSqlRepository<,>),
                typeof(FreeSqlEfRepositoryBase<,>),
                typeof(FreeSqlEfRepositoryBase<,,>)
            );
        }

        public static FreeSqlAutoRepositoryTypeAttribute Default { get; }
    }
}
