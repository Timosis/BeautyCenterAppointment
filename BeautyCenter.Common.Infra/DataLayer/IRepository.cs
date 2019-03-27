using BeautyCenter.Common.Infra.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Common.Infra.DataLayer
{
    
    public interface IRepository 
    {
        void Create<TEntity>(TEntity entity)
      where TEntity : class, IEntity;

        void Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Delete<TEntity>(object id)
            where TEntity : class, IEntity;

        void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        int Save();

        Task<int> SaveAsync();
    }
}
