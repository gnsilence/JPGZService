using Abp.Data;
using Abp.Domain.Entities;
using Abp.Events.Bus.Entities;
using FreeSql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Abp.FreeSqlExtensions.FreeSqlExt.Repositories
{
    public class FreeSqlRepositoryBase<TEntity, TPrimaryKey> : AbpFreeSqlRepositoryBase<TEntity, TPrimaryKey>
          where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IActiveTransactionProvider _activeTransactionProvider;
        private readonly IDataTypeByEfContext _dataTypeByEfContext;
        public IEntityChangeEventHelper EntityChangeEventHelper { get; set; }
        public FreeSqlRepositoryBase(IActiveTransactionProvider activeTransactionProvider, IDataTypeByEfContext dataTypeByEfContext)
        {
            _activeTransactionProvider = activeTransactionProvider;
            _dataTypeByEfContext = dataTypeByEfContext;
            EntityChangeEventHelper = NullEntityChangeEventHelper.Instance;
        }
        public virtual DbConnection Connection
        {
            get { return (DbConnection)_activeTransactionProvider.GetActiveConnection(ActiveTransactionProviderArgs.Empty); }
        }
        public virtual DataType DbType
        {
            get
            {
                var str = _dataTypeByEfContext.GetDbType(string.Empty);
                return str;
            }
        }
        public virtual DbTransaction ActiveTransaction
        {
            get { return (DbTransaction)_activeTransactionProvider.GetActiveConnection(ActiveTransactionProviderArgs.Empty); }
        }
        public IFreeSql DataBase
        {
            get
            {
                var database = new FreeSql.FreeSqlBuilder()
                    .UseConnectionString(DbType, Connection.ConnectionString)
                    .UseAutoSyncStructure(false) //自动同步实体结构到数据库
                    .UseConfigEntityFromDbFirst(true)
                    .UseMonitorCommand(
                    cmd => Console.WriteLine(cmd.CommandText), //监听SQL命令对象，在执行前
                    (cmd, traceLog) => Console.WriteLine(traceLog)) //监听SQL命令对象，在执行后
                    .Build();

                database.Aop.ConfigEntity = (s, e) =>
                {
                    if (e.EntityType.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.TableAttribute), false).FirstOrDefault() is System.ComponentModel.DataAnnotations.Schema.TableAttribute attr)
                        e.ModifyResult.Name = attr.Name;
                };

                database.Aop.ConfigEntityProperty = (s, e) =>
                {
                    if (e.Property.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.KeyAttribute), false).Any())
                        e.ModifyResult.IsPrimary = true;
                };
                return database;
            }
        }
        /// <summary>
        /// get Count by Expression predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public override int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Convert.ToInt32(DataBase.Select<TEntity>()
                .Where(predicate)
                .WithConnection(Connection)
                .WithTransaction(transaction: ActiveTransaction)
                .Count());
        }

        public override void Delete(TEntity entity)
        {
            EntityChangeEventHelper.TriggerEntityDeletingEvent(entity);
            if (entity is ISoftDelete)
            {
                Update(entity);
            }
            else
            {
                DataBase.Delete<TEntity>(entity).WithConnection(Connection).WithTransaction(transaction: ActiveTransaction).ExecuteAffrows();
            }
            EntityChangeEventHelper.TriggerEntityDeletedEventOnUowCompleted(entity);
        }

        public override void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> items = GetAll(predicate);
            foreach (TEntity entity in items)
            {
                Delete(entity);
            }
        }

        public override int Execute(string query, object parameters = null)
        {
            int reslut = 0;
            DataBase.Ado.Transaction(() =>
            {
                reslut = DataBase.Ado.ExecuteNonQuery(query, parameters);
            });
            return reslut;
        }

        public override TEntity FirstOrDefault(TPrimaryKey id)
        {
            return DataBase.Select<TEntity>()
                .Where(p => p.Id.Equals(id))
                .WithConnection(Connection)
                .WithTransaction(transaction: ActiveTransaction)
                .First();
        }

        public override TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DataBase.Select<TEntity>()
                .Where(predicate)
                .WithConnection(Connection)
                .WithTransaction(transaction: ActiveTransaction)
                .First();
        }

        public override TEntity Get(TPrimaryKey id)
        {
            var entity = DataBase.Select<TEntity>()
                .Where(p => p.Id.Equals(id))
                .WithConnection(Connection)
                .WithTransaction(transaction: ActiveTransaction)
                .First();
            return entity;
        }

        public override IEnumerable<TEntity> GetAll()
        {
            return DataBase.Select<TEntity>().WithConnection(Connection).WithTransaction(transaction: ActiveTransaction).ToList();
        }

        public override IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return DataBase.Select<TEntity>()
                .Where(predicate)
                .WithConnection(Connection)
                .WithTransaction(transaction: ActiveTransaction)
                .ToList();
        }

        public override void Insert(TEntity entity)
        {
            InsertAndGetEntity(entity);
        }
        /// <summary>
        /// Insert and get entity（this method for mysql only Support identityPrimaryKey int or long ）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override TEntity InsertAndGetEntity(TEntity entity)
        {
            EntityChangeEventHelper.TriggerEntityCreatingEvent(entity);
            if ((DbType == DataType.SqlServer) || (DbType == DataType.PostgreSQL))
            {
                entity = DataBase.Insert(entity)
               .WithConnection(Connection)
               .WithTransaction(transaction: ActiveTransaction)
               .ExecuteInserted().First();
            }
            else
            {
                var identityid = DataBase.Insert(entity)
               .WithConnection(Connection)
               .WithTransaction(transaction: ActiveTransaction)
               .ExecuteIdentity();
                try
                {
                    entity.Id = Convert.ToInt32((dynamic)identityid);
                }
                catch (Exception)
                {
                    throw new NotSupportedException("for mysql only Support int or long type PrimaryKey");
                }
            }
            EntityChangeEventHelper.TriggerEntityCreatedEventOnUowCompleted(entity);
            return entity;
        }

        public override IEnumerable<TEntity> Query(string query, object parameters = null)
        {
            return DataBase.Ado.Query<TEntity>(query, parameters);
        }

        public override IEnumerable<TAny> Query<TAny>(string query, object parameters = null)
        {
            return DataBase.Ado.Query<TAny>(query);
        }

        public override TEntity Single(TPrimaryKey id)
        {
            return DataBase.Select<TEntity>()
                .Where(e => e.Id.Equals(id)).
                WithConnection(Connection)
                .WithTransaction(transaction: ActiveTransaction)
                .First();
        }

        public override TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return DataBase.Select<TEntity>().Where(predicate).
               WithConnection(Connection).WithTransaction(transaction: ActiveTransaction)
               .First();
        }

        public override void Update(TEntity entity)
        {
            EntityChangeEventHelper.TriggerEntityUpdatingEvent(entity);
            DataBase.Update<TEntity>().WithConnection(Connection)
                .WithTransaction(transaction: ActiveTransaction)
                .SetSource(entity).ExecuteAffrows();
            EntityChangeEventHelper.TriggerEntityUpdatedEventOnUowCompleted(entity);
        }

        public override int Updates(IEnumerable<TEntity> entities)
        {
            return DataBase.Update<TEntity>()
               .WithConnection(Connection)
               .WithTransaction(transaction: ActiveTransaction)
               .SetSource(entities).ExecuteAffrows();
        }

        public override int Update(object dywhere)
        {
            return DataBase.Update<TEntity>(dywhere)
               .WithConnection(Connection)
               .WithTransaction(transaction: ActiveTransaction).ExecuteAffrows();
        }

        public override int Inserts(IEnumerable<TEntity> entities)
        {
            return DataBase.Insert<TEntity>()
                  .WithConnection(Connection)
                  .WithTransaction(transaction: ActiveTransaction)
                  .AppendData(entities).ExecuteAffrows();
        }

        public override TEntity UpdateAndGetEntity(TEntity entity)
        {
            if (DbType == DataType.MySql)
            {
                throw new NotSupportedException("Mysql Not Support UpdateAndGetEntity");
            }
            else
            {
                EntityChangeEventHelper.TriggerEntityUpdatingEvent(entity);
                var updated = DataBase.Update<TEntity>().WithConnection(Connection)
                     .WithTransaction(transaction: ActiveTransaction)
                     .SetSource(entity).ExecuteUpdated();
                EntityChangeEventHelper.TriggerEntityUpdatedEventOnUowCompleted(entity);
                return updated.FirstOrDefault();
            }
           
        }
    }
}
