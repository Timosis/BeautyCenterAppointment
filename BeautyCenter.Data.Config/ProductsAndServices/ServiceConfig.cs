using BeautyCenter.Data.Entities.ProductsAndServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.ProductsAndServices
{
    public class ServiceConfig : BaseConfig<Service>
    {
        public override void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable(nameof(Service), Constants.Schemas.Service);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150).HasColumnType(Constants.DataTypes.VarChar);
            builder.Property(p => p.Duration).IsRequired().HasMaxLength(150).HasColumnType(Constants.DataTypes.Integer);
            builder.Property(p => p.Amount).IsRequired().HasMaxLength(150).HasColumnType(Constants.DataTypes.Decimal);
            builder.Property(p => p.ColorClass).IsRequired().HasMaxLength(150).HasColumnType(Constants.DataTypes.VarChar);
            base.Configure(builder);
        }
    }
}
