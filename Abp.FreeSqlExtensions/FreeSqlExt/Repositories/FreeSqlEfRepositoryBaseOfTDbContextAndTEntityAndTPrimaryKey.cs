using Abp.Data;
using Abp.Domain.Entities;
using FreeSql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Abp.FreeSqlExtensions.FreeSqlExt.Repositories
{
    public class FreeSqlEfRepositoryBase<TDbContext, TEntity, TPrimaryKey>: FreeSqlRepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IActiveTransactionProvider _activeTransactionProvider;
        private readonly IDataTypeByEfContext _dataTypeByEfContext;

        public FreeSqlEfRepositoryBase(IActiveTransactionProvider activeTransactionProvider, IDataTypeByEfContext dataTypeByEfContext) : base(activeTransactionProvider, dataTypeByEfContext)
        {
            _activeTransactionProvider = activeTransactionProvider;
            _dataTypeByEfContext = dataTypeByEfContext;
        }
        public ActiveTransactionProviderArgs ActiveTransactionProviderArgs
        {
            get
            {
                return new ActiveTransactionProviderArgs
                {
                    ["ContextType"] = typeof(TDbContext),
                    ["MultiTenancySide"] = MultiTenancySide
                };
            }
        }
        public override DbConnection Connection => (DbConnection)_activeTransactionProvider.GetActiveConnection(ActiveTransactionProviderArgs);

        public override DbTransaction ActiveTransaction => (DbTransaction)_activeTransactionProvider.GetActiveTransaction(ActiveTransactionProviderArgs);

        public override DataType DbType => _dataTypeByEfContext.GetDbType(typeof(TDbContext).ToString());
    }
}
