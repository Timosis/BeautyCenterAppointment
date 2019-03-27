using BeautyCenter.Data.Entities.Installments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Installments
{
    public class InstallmentDetailConfig : BaseConfig<InstallmentDetail>
    {
        public override void Configure(EntityTypeBuilder<InstallmentDetail> builder)
        {
            builder.ToTable(nameof(InstallmentDetail), Constants.Schemas.Installment);
            builder.Property(p => p.InstallmentDate).IsRequired().HasColumnType(Constants.DataTypes.Datetime);
            builder.Property(p => p.Amount).IsRequired().HasColumnType(Constants.DataTypes.Decimal);
            builder.Property(p => p.PaymentState).IsRequired().HasColumnType(Constants.DataTypes.Integer);
            base.Configure(builder);
        }
    }
}
