using BeautyCenter.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Customers
{
    public class CustomerConfig : BaseConfig<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer), Constants.Schemas.Customer);
            builder.Property(p => p.Firstname).IsRequired().HasMaxLength(150).HasColumnType(Constants.DataTypes.VarChar);
            builder.Property(p => p.Lastname).IsRequired().HasMaxLength(150).HasColumnType(Constants.DataTypes.VarChar);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(150).HasColumnType(Constants.DataTypes.VarChar);
            builder.Property(p => p.Telephone).IsRequired().HasMaxLength(150).HasColumnType(Constants.DataTypes.VarChar);            
            base.Configure(builder);
        }
    }
}
