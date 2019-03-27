using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BeautyCenter.Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<BeautyCenterContext>
    {
       
        BeautyCenterContext IDesignTimeDbContextFactory<BeautyCenterContext>.CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BeautyCenterContext>();
            builder.UseSqlServer("Server=Tumer;Database=BeautyCenterDb;User ID=sa;Password=1234qqqQ;TrustServerCertificate=True;Trusted_Connection=False;Connection Timeout=30;Integrated Security=False;Persist Security Info=False;Encrypt=True;MultipleActiveResultSets=True;",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(BeautyCenterContext).GetTypeInfo().Assembly.GetName().Name));

            return new BeautyCenterContext(builder.Options);
        }
    }
}
