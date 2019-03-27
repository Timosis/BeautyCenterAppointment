using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Context.UnitOfWork
{
    public class DbFactory : IDbFactory, IDisposable
    {
        private BeautyCenterContext dbContext;
        public DbFactory(BeautyCenterContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public BeautyCenterContext GetBeautyCenterContext
        {
            get
            {
                return this.dbContext;
            }
        }

        private bool isDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                }
            }
            isDisposed = true;
        }
    }
}
