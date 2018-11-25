using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Context.UnitOfWork
{
    public interface IDbFactory
    {
        BeautyCenterContext GetBeautyCenterContext { get; }
    }
}
