using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Context.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbFactory dbFactory;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void BeginTransaction()
        {
            dbFactory.GetBeautyCenterContext.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            dbFactory.GetBeautyCenterContext.Database.RollbackTransaction();
        }

        public void CommitTransaction()
        {
            dbFactory.GetBeautyCenterContext.Database.CommitTransaction();
        }

        public void SaveChanges()
        {
            dbFactory.GetBeautyCenterContext.Save();
        }
    }
}
