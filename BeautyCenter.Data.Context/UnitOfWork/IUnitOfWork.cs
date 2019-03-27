using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Context.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void RollbackTransaction();

        void CommitTransaction();

        void SaveChanges();
    }
}
