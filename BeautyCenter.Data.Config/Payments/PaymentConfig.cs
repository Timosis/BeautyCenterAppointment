using BeautyCenter.Data.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Payments
{
    public class PaymentConfig : BaseConfig<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable(nameof(Payment), Constants.Schemas.Payment);
            builder.Property(p => p.PaymentDate).IsRequired().HasColumnType(Constants.DataTypes.Datetime);
            builder.Property(p => p.PaymentAmount).IsRequired().HasColumnType(Constants.DataTypes.Decimal);
            base.Configure(builder);
        }
    }
}
