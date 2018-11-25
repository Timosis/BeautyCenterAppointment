using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Context
{
    public class BeautyCenterContext : DbContext
    {
        public BeautyCenterContext(DbContextOptions<BeautyCenterContext> options) : base(options)
        {
        }
    }
}
