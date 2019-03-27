using BeautyCenter.Common.Infra.DataLayer;
using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Context.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Data.Context
{
    public class EntityFrameworkRepository : EntityFrameworkReadOnlyRepository, IRepository
    {

        public EntityFrameworkRepository(IDbFactory dbFactory): base(dbFactory)
        {
            this.dbContext = dbFactory.GetBeautyCenterContext;
        }

        public virtual void Create<TEntity>(TEntity entity)
        where TEntity : class, IEntity
        {
            dbContext.Set<TEntity>().Add(entity);
        }
        public virtual void Update<TEntity>(TEntity entity)
        where TEntity : class, IEntity
        {
            dbContext.Set<TEntity>().Attach(entity);
        }

        public virtual void Delete<TEntity>(object id)
           where TEntity : class, IEntity
        {
            TEntity entity = dbContext.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity)
         where TEntity : class, IEntity
        {
            var dbSet = dbContext.Set<TEntity>();

            dbSet.Attach(entity);
        

            dbSet.Remove(entity);
        }

        public virtual int Save()
        {
            //TODO Validation will be added
            dbContext.SaveChanges();

            return 0;
        }

        public virtual Task<int> SaveAsync()
        {
            //TODO Validation will be added
            dbContext.SaveChangesAsync();
            return Task.FromResult(0);
        }
    }
}
