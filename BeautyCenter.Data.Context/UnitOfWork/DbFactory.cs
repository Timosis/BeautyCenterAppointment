using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Context.UnitOfWork
{
    public class DbFactory
    {
        private BeautyCenterContext beautyCenterContext;

        public DbFactory(BeautyCenterContext beautyCenterContext)
        {
            this.beautyCenterContext = beautyCenterContext;
        }
        public BeautyCenterContext GetBeautyCenterContext
        {
            get
            {
                return beautyCenterContext;
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
                if (beautyCenterContext != null)
                {
                    beautyCenterContext.Dispose();
                }
            }
            isDisposed = true;
        }
    }
}
