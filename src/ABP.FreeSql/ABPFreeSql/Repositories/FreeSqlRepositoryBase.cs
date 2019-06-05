using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using FreeSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP.FreeSqlSqlserver.ABPFreeSql.Repositories
{
    public class FreeSqlRepositoryBase<TEntity> : FreeSqlRepositoryBase<TEntity, int>, IRepository<TEntity>
         where TEntity : class, IEntity<int>
    {
    }

    public class FreeSqlRepositoryBase<TEntity, TPrimaryKey> : AbpRepositoryBase<TEntity, TPrimaryKey>, IFreeSqlRepository<TEntity>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        IUpdate<TEntity> UpdateEntity => IFreeSqlProvider.Database.Update<TEntity>();
        ISelect<TEntity> Select => IFreeSqlProvider.Database.Select<TEntity>();
        public virtual List<TEntity> GetEntityCollection
        {
            get
            {
                InitConfig();
                var list = Select.ToList();
                return list;
            }
        }

        public override IQueryable<TEntity> GetAll()
        {
            return GetEntityCollection.ToList().AsQueryable();
        }

        public override TEntity Get(TPrimaryKey id)
        {
            var entity = GetEntityCollection.Where(e => EqualityComparer<TPrimaryKey>.Default.Equals(e.Id, id)).First();
            if (entity == null)
            {
                throw new EntityNotFoundException(
                    $"There is no such an entity with given id. Entity type:{typeof(TEntity).FullName} ,id is {id}"
                    );
            }
            return entity;
        }
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override TEntity Insert(TEntity entity)
        {
            return IFreeSqlProvider.Database
                 .Insert(entity)
                 .ExecuteInserted().First();
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override TEntity Update(TEntity entity)
        {
            var sql = UpdateEntity.SetSource(entity).ToSql();
            return UpdateEntity.SetSource(entity).ExecuteUpdated().FirstOrDefault();
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"></param>
        public override void Delete(TEntity entity)
        {
            _ = IFreeSqlProvider.Database.Delete<TEntity>(entity).ExecuteDeleted().FirstOrDefault();
        }
        /// <summary>
        /// 根据主键id删除
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(TPrimaryKey id)
        {
            var entity = GetEntityCollection.Where(e => EqualityComparer<TPrimaryKey>.Default.Equals(e.Id, id)).FirstOrDefault();
            if (entity == null)
            {
                throw new EntityNotFoundException(
                    $"There is no such an entity with given id. Entity type:{typeof(TEntity).FullName} ,id is {id}"
                    );
            }
            else
            {
                IFreeSqlProvider.Database.Delete<TEntity>(entity).ExecuteAffrows();
            }
        }
        private void InitConfig()
        {
            IFreeSqlProvider.Database.Aop.ConfigEntity = (s, e) =>
            {
                var attr = e.EntityType.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.TableAttribute), false).FirstOrDefault() as System.ComponentModel.DataAnnotations.Schema.TableAttribute;
                if (attr != null)
                    e.ModifyResult.Name = attr.Name;
            };

            IFreeSqlProvider.Database.Aop.ConfigEntityProperty = (s, e) =>
            {
                if (e.Property.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.KeyAttribute), false).Any())
                    e.ModifyResult.IsPrimary = true;
            };
        }

        public  TEntity GetEntityBySql()
        {
            return IFreeSqlProvider.Database.Ado.Query<TEntity>("SELECT * FROM dbo.tb_News WHERE ID=24").FirstOrDefault();
        }
    }
}
