using BeautyCenter.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Operations
{
    public class OperationConfig : BaseConfig<Operation>
    {
        public override void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.ToTable(nameof(Operation), Constants.Schemas.Operation);
            builder.Property(p => p.Datetime).IsRequired().HasColumnType(Constants.DataTypes.Datetime);
            builder.Property(p => p.Amount).IsRequired().HasColumnType(Constants.DataTypes.Float);
            builder.Property(p => p.IsPaid).IsRequired().HasColumnType(Constants.DataTypes.Bit);
            base.Configure(builder);
        }
    }
}
