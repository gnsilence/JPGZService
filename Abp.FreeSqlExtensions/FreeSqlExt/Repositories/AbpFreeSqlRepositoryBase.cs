using Abp.Domain.Entities;
using Abp.MultiTenancy;
using Abp.Reflection.Extensions;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abp.FreeSqlExtensions.FreeSqlExt.Repositories
{
    public abstract class AbpFreeSqlRepositoryBase<TEntity, TPrimaryKey> : IFreeSqlRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        public static MultiTenancySides? MultiTenancySide { get; private set; }

        static AbpFreeSqlRepositoryBase()
        {
            var attr = typeof(TEntity).GetSingleAttributeOfTypeOrBaseTypesOrNull<MultiTenancySideAttribute>();
            if (attr != null)
            {
                MultiTenancySide = attr.Side;
            }
        }

        public abstract TEntity Single(TPrimaryKey id);

        public abstract IEnumerable<TEntity> GetAll();

        public virtual Task<TEntity> SingleAsync(TPrimaryKey id)
        {
            return Task.FromResult(Single(id));
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(GetAll());
        }

        public abstract IEnumerable<TEntity> Query(string query, object parameters = null);

        public virtual Task<IEnumerable<TEntity>> QueryAsync(string query, object parameters = null)
        {
            return Task.FromResult(Query(query, parameters));
        }

        public abstract IEnumerable<TAny> Query<TAny>(string query, object parameters = null) where TAny : class;

        public virtual Task<IEnumerable<TAny>> QueryAsync<TAny>(string query, object parameters = null) where TAny : class
        {
            return Task.FromResult(Query<TAny>(query, parameters));
        }

        public abstract int Execute(string query, object parameters = null);

        public virtual Task<int> ExecuteAsync(string query, object parameters = null)
        {
            return Task.FromResult(Execute(query, parameters));
        }

        public abstract IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        public virtual Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(GetAll(predicate));
        }

        public abstract int Count(Expression<Func<TEntity, bool>> predicate);

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(Count(predicate));
        }

        public abstract void Insert(TEntity entity);

        public virtual Task InsertAsync(TEntity entity)
        {
            Insert(entity);
            return Task.FromResult(0);
        }

        public abstract void Update(TEntity entity);

        public abstract int Updates(IEnumerable<TEntity> entities);

        public abstract int Update(object dywhere);

        public abstract int Inserts(IEnumerable<TEntity> entities);

        public abstract TEntity UpdateAndGetEntity(TEntity entity);

        public virtual Task<TEntity> UpdateAndGetEntityAsync(TEntity entity)
        {
            return Task.FromResult(UpdateAndGetEntity(entity));
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            Update(entity);
            return Task.FromResult(0);
        }

        public abstract void Delete(TEntity entity);

        public virtual Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.FromResult(0);
        }

        public abstract void Delete(Expression<Func<TEntity, bool>> predicate);

        public virtual Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Delete(predicate);
            return Task.FromResult(0);
        }

        public abstract TEntity InsertAndGetEntity(TEntity entity);

        public virtual Task<TEntity> InsertAndGetEntityAsync(TEntity entity)
        {
            return Task.FromResult(InsertAndGetEntity(entity));
        }

        public abstract TEntity Single(Expression<Func<TEntity, bool>> predicate);

        public virtual Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(Single(predicate));
        }

        public abstract TEntity FirstOrDefault(TPrimaryKey id);

        public virtual Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return Task.FromResult(FirstOrDefault(id));
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(FirstOrDefault(predicate));
        }

        public abstract TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        public abstract TEntity Get(TPrimaryKey id);

        public virtual Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return Task.FromResult(Get(id));
        }
        /// <summary>
        /// get expression for id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            ParameterExpression lambdaParam = Expression.Parameter(typeof(TEntity));

            BinaryExpression lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
            );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }
}
