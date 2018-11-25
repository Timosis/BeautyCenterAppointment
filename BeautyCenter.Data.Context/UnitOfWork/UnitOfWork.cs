﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Context.UnitOfWork
{
    public class UnitOfWork
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
        public void CommitTransaction()
        {
            dbFactory.GetBeautyCenterContext.Database.CommitTransaction();
        }
        public void RollbackTransaction()
        {
            dbFactory.GetBeautyCenterContext.Database.RollbackTransaction();
        }
        public void SaveChanges()
        {
            dbFactory.GetBeautyCenterContext.SaveChanges();
        }
    }
}
