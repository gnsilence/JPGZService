using Abp.Dependency;
using Abp.Modules;
using Abp.Orm;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.FreeSqlExtensions.FreeSqlExt
{
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpFreeSqlExtensionsModule:AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactionScopeAvailable = false;
            IocManager.Register<IDataTypeByEfContext, DataTypeByEfContext>();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpFreeSqlExtensionsModule).GetAssembly());

            using (IScopedIocResolver scope = IocManager.CreateScope())
            {
                ISecondaryOrmRegistrar[] additionalOrmRegistrars = scope.ResolveAll<ISecondaryOrmRegistrar>();

                foreach (ISecondaryOrmRegistrar registrar in additionalOrmRegistrars)
                {
                    if (registrar.OrmContextKey == "EntityFramework")
                    {
                        registrar.RegisterRepositories(IocManager, EfBasedFreeSqlAutoRepositoryTypes.Default);
                    }

                    if (registrar.OrmContextKey == "NHibernate")
                    {
                        registrar.RegisterRepositories(IocManager, NhBasedFreeSqlAutoRepositoryTypes.Default);
                    }

                    if (registrar.OrmContextKey == "EntityFrameworkCore")
                    {
                        registrar.RegisterRepositories(IocManager, EfBasedFreeSqlAutoRepositoryTypes.Default);
                    }
                }
            }
        }
    }
}
