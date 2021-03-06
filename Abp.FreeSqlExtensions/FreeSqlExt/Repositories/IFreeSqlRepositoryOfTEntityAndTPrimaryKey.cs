﻿using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abp.FreeSqlExtensions.FreeSqlExt.Repositories
{
    public interface IFreeSqlRepository<TEntity, TPrimaryKey> : IRepository where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [NotNull]
        TEntity Single([NotNull] TPrimaryKey id);

        /// <summary>
        ///     Gets the Entity with specified predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        [NotNull]
        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Gets the Entity with specified predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [NotNull]
        Task<TEntity> SingleAsync([NotNull] TPrimaryKey id);

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [NotNull]
        TEntity Get([NotNull] TPrimaryKey id);

        /// <summary>
        ///     Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [NotNull]
        Task<TEntity> GetAsync([NotNull] TPrimaryKey id);

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [CanBeNull]
        TEntity FirstOrDefault([NotNull] TPrimaryKey id);

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [CanBeNull]
        Task<TEntity> FirstOrDefaultAsync([NotNull] TPrimaryKey id);

        /// <summary>
        ///     Gets the Entity with specified predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        [CanBeNull]
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Gets the Entity with specified predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        [CanBeNull]
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Gets the list.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        IEnumerable<TEntity> GetAll();

        /// <summary>
        ///     Gets the list asynchronous.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        ///     Gets the list.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        [NotNull]
        IEnumerable<TEntity> GetAll([NotNull] Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Gets the list asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        [NotNull]
        Task<IEnumerable<TEntity>> GetAllAsync([NotNull] Expression<Func<TEntity, bool>> predicate);

        ///// <summary>
        /////     Gets the list paged asynchronous.
        ///// </summary>
        ///// <param name="predicate">The predicate.</param>
        ///// <param name="pageNumber">The page number.</param>
        ///// <param name="itemsPerPage">The items per page.</param>
        ///// <param name="sortingProperty">The sorting property.</param>
        ///// <param name="ascending">if set to <c>true</c> [ascending].</param>
        ///// <returns></returns>
        //[NotNull]
        //Task<IEnumerable<TEntity>> GetAllPagedAsync([NotNull] Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, [NotNull] string sortingProperty, bool ascending = true);

        ///// <summary>
        /////     Gets the list paged asynchronous.
        ///// </summary>
        ///// <param name="predicate">The predicate.</param>
        ///// <param name="pageNumber">The page number.</param>
        ///// <param name="itemsPerPage">The items per page.</param>
        ///// <param name="sortingExpression">The sorting expression.</param>
        ///// <param name="ascending">if set to <c>true</c> [ascending].</param>
        ///// <returns></returns>
        //[NotNull]
        //Task<IEnumerable<TEntity>> GetAllPagedAsync([NotNull] Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, [NotNull] params Expression<Func<TEntity, object>>[] sortingExpression);

        ///// <summary>
        /////     Gets the list paged.
        ///// </summary>
        ///// <param name="predicate">The predicate.</param>
        ///// <param name="pageNumber">The page number.</param>
        ///// <param name="itemsPerPage">The items per page.</param>
        ///// <param name="sortingProperty">The sorting property.</param>
        ///// <param name="ascending">if set to <c>true</c> [ascending].</param>
        ///// <returns></returns>
        //[NotNull]
        //IEnumerable<TEntity> GetAllPaged([NotNull] Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, [NotNull] string sortingProperty, bool ascending = true);

        ///// <summary>
        /////     Gets the list paged.
        ///// </summary>
        ///// <param name="predicate">The predicate.</param>
        ///// <param name="pageNumber">The page number.</param>
        ///// <param name="itemsPerPage">The items per page.</param>
        ///// <param name="sortingExpression">The sorting expression.</param>
        ///// <param name="ascending">if set to <c>true</c> [ascending].</param>
        ///// <returns></returns>
        //[NotNull]
        //IEnumerable<TEntity> GetAllPaged([NotNull] Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, [NotNull] params Expression<Func<TEntity, object>>[] sortingExpression);

        /// <summary>
        ///     Counts the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        int Count([NotNull] Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Counts the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        [NotNull]
        Task<int> CountAsync([NotNull] Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Queries the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        [NotNull]
        IEnumerable<TEntity> Query([NotNull] string query, [CanBeNull] object parameters = null);

        /// <summary>
        ///     Queries the asynchronous.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        [NotNull]
        Task<IEnumerable<TEntity>> QueryAsync([NotNull] string query, [CanBeNull] object parameters = null);

        /// <summary>
        ///     Queries the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        [NotNull]
        IEnumerable<TAny> Query<TAny>([NotNull] string query, [CanBeNull] object parameters = null) where TAny : class;

        /// <summary>
        ///     Queries the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        [NotNull]
        Task<IEnumerable<TAny>> QueryAsync<TAny>([NotNull] string query, [CanBeNull] object parameters = null) where TAny : class;

        /// <summary>
        ///     Executes the given query text
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        int Execute([NotNull] string query, [CanBeNull] object parameters = null);

        /// <summary>
        ///     Executes as async the given query text
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        Task<int> ExecuteAsync([NotNull] string query, [CanBeNull] object parameters = null);

        ///// <summary>
        /////     Gets the set.
        ///// </summary>
        ///// <param name="predicate">The predicate.</param>
        ///// <param name="firstResult">The first result.</param>
        ///// <param name="maxResults">The maximum results.</param>
        ///// <param name="sortingProperty">The sorting property.</param>
        ///// <param name="ascending">if set to <c>true</c> [ascending].</param>
        ///// <returns></returns>
        //[NotNull]
        //IEnumerable<TEntity> GetSet([NotNull] Expression<Func<TEntity, bool>> predicate, int firstResult, int maxResults, [NotNull] string sortingProperty, bool ascending = true);

        ///// <summary>
        /////     Gets the set.
        ///// </summary>
        ///// <param name="predicate">The predicate.</param>
        ///// <param name="firstResult">The first result.</param>
        ///// <param name="maxResults">The maximum results.</param>
        ///// <param name="sortingExpression">The sorting expression.</param>
        ///// <param name="ascending">if set to <c>true</c> [ascending].</param>
        ///// <returns></returns>
        //[NotNull]
        //IEnumerable<TEntity> GetSet([NotNull] Expression<Func<TEntity, bool>> predicate, int firstResult, int maxResults, bool ascending = true, [NotNull] params Expression<Func<TEntity, object>>[] sortingExpression);

        ///// <summary>
        /////     Gets the set asynchronous.
        ///// </summary>
        ///// <param name="predicate">The predicate.</param>
        ///// <param name="firstResult">The first result.</param>
        ///// <param name="maxResults">The maximum results.</param>
        ///// <param name="sortingProperty">The sorting property.</param>
        ///// <param name="ascending">if set to <c>true</c> [ascending].</param>
        ///// <returns></returns>
        //[NotNull]
        //Task<IEnumerable<TEntity>> GetSetAsync([NotNull] Expression<Func<TEntity, bool>> predicate, int firstResult, int maxResults, [NotNull] string sortingProperty, bool ascending = true);

        ///// <summary>
        /////     Gets the set asynchronous.
        ///// </summary>
        ///// <param name="predicate">The predicate.</param>
        ///// <param name="firstResult">The first result.</param>
        ///// <param name="maxResults">The maximum results.</param>
        ///// <param name="ascending">if set to <c>true</c> [ascending].</param>
        ///// <param name="sortingExpression">The sorting expression.</param>
        ///// <returns></returns>
        //[NotNull]
        //Task<IEnumerable<TEntity>> GetSetAsync([NotNull] Expression<Func<TEntity, bool>> predicate, int firstResult, int maxResults, bool ascending = true, [NotNull] params Expression<Func<TEntity, object>>[] sortingExpression);

        /// <summary>
        ///     Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert([NotNull] TEntity entity);

        /// <summary>
        ///     Inserts the and get inserted entity (for mysql only Support int or long type PrimaryKey)
        /// </summary>
        /// <param name="entity">The entity.</param>
        TEntity InsertAndGetEntity([NotNull] TEntity entity);

        /// <summary>
        ///     Inserts the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [NotNull]
        Task InsertAsync([NotNull] TEntity entity);

        /// <summary>
        ///     Inserts the and get inserted entity (for mysql only Support int or long type PrimaryKey)
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [NotNull]
        Task<TEntity> InsertAndGetEntityAsync([NotNull] TEntity entity);

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update([NotNull] TEntity entity);

        /// <summary>
        ///     Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        [NotNull]
        Task UpdateAsync([NotNull] TEntity entity);

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete([NotNull] TEntity entity);

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        void Delete([NotNull] Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [NotNull]
        Task DeleteAsync([NotNull] TEntity entity);

        /// <summary>
        ///     Deletes the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        [NotNull]
        Task DeleteAsync([NotNull] Expression<Func<TEntity, bool>> predicate);

        #region FreesqlSpecial
        /// <summary>
        /// Update Many IEnumerable entities
        /// </summary>
        /// <param name="entities"></param>
        [NotNull]
        int Updates([NotNull] IEnumerable<TEntity> entities);
        /// <summary>
        /// Update By object where
        /// </summary>
        /// <param name="dywhere"></param>
        [NotNull]

        int Update([NotNull]object dywhere);
        /// <summary>
        /// insert entities by IEnumerable list
        /// </summary>
        /// <param name="entities"></param>
        [NotNull]
        int Inserts([NotNull] IEnumerable<TEntity> entities);
        /// <summary>
        /// update entity and get updated entity (not Support for mysql)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [NotNull]
        TEntity UpdateAndGetEntity([NotNull]TEntity entity);
        /// <summary>
        /// update entity and get updated entity (not Support for mysql)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [NotNull]
        Task<TEntity> UpdateAndGetEntityAsync([NotNull]TEntity entity);
        #endregion
    }
}
