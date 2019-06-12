using Abp.FreeSqlExtensions.FreeSqlExt.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.FreeSqlExtensions.FreeSqlExt
{
    public class NhBasedFreeSqlAutoRepositoryTypes
    {
        static NhBasedFreeSqlAutoRepositoryTypes()
        {
            Default = new FreeSqlAutoRepositoryTypeAttribute(
                typeof(IFreeSqlRepository<>),
                typeof(IFreeSqlRepository<,>),
                typeof(FreeSqlRepositoryBase<>),
                typeof(FreeSqlRepositoryBase<,>)
            );
        }

        public static FreeSqlAutoRepositoryTypeAttribute Default { get; }
    }
}
