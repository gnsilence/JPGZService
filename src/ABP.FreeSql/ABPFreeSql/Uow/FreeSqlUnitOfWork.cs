using Abp.Dependency;
using Abp.Domain.Uow;
using ABP.FreeSqlSqlserver.ABPFreeSql.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABP.FreeSqlSqlserver.ABPFreeSql.Uow
{
    /// <summary>
    /// 由于abp内部只支持EFCore的单元事务，暂时留着有时间拓展
    /// </summary>
    public class FreeSqlUnitOfWork : UnitOfWorkBase, ITransientDependency
    {
        public IFreeSql freeSql { get; private set; }
        private readonly IAbpFreesqlModuleConfiguration _configuration;
        public FreeSqlUnitOfWork(
            IAbpFreesqlModuleConfiguration configuration, 
            IConnectionStringResolver connectionStringResolver,
            IUnitOfWorkFilterExecuter filterExecuter,
            IUnitOfWorkDefaultOptions defaultOptions)
            :base(connectionStringResolver,
                  defaultOptions,
                  filterExecuter)
        {
            _configuration = configuration;
        }
        protected override void BeginUow()
        {

            freeSql= new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.SqlServer,_configuration.ConnectionString)
                .UseAutoSyncStructure(true) //自动同步实体结构到数据库
                .Build();
        }
        public override void SaveChanges()
        {
        }
        #pragma warning disable 1998
        public override async Task SaveChangesAsync()
        {
        }

        protected override void CompleteUow()
        {
        }
        #pragma warning disable 1998
        protected override async Task CompleteUowAsync()
        {
        }

        protected override void DisposeUow()
        {
        }
    }
}
