using BeautyCenter.Data.Entities.Installments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Installments
{
    public class InstallmentConfig : BaseConfig<Installment>
    {
        public override void Configure(EntityTypeBuilder<Installment> builder)
        {
            builder.ToTable(nameof(Installment), Constants.Schemas.Installment);
            builder.Property(p => p.InstallmentDate).IsRequired().HasColumnType(Constants.DataTypes.Datetime);
            builder.Property(p => p.TotalAmount).IsRequired().HasColumnType(Constants.DataTypes.Decimal);
            base.Configure(builder);
        }
    }
}
