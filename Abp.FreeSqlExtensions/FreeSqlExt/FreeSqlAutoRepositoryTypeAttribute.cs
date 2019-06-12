using Abp.Domain.Repositories;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.FreeSqlExtensions.FreeSqlExt
{
    public class FreeSqlAutoRepositoryTypeAttribute : AutoRepositoryTypesAttribute
    {
        public FreeSqlAutoRepositoryTypeAttribute(
            [NotNull] Type repositoryInterface,
            [NotNull] Type repositoryInterfaceWithPrimaryKey,
            [NotNull] Type repositoryImplementation,
            [NotNull] Type repositoryImplementationWithPrimaryKey)
            : base(repositoryInterface, repositoryInterfaceWithPrimaryKey, repositoryImplementation, repositoryImplementationWithPrimaryKey)
        {
        }
    }
}
