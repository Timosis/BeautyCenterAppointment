using BeautyCenter.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Operations
{
    public class OperationDetailConfig : BaseConfig<OperationDetail>
    {
        public override void Configure(EntityTypeBuilder<OperationDetail> builder)
        {
            builder.ToTable(nameof(OperationDetail), Constants.Schemas.Operation);
            builder.Property(p => p.DateTime).IsRequired().HasColumnType(Constants.DataTypes.Datetime);
            builder.Property(p => p.Description).IsRequired().HasColumnType(Constants.DataTypes.VarChar);
            builder.Property(p => p.Area).IsRequired().HasColumnType(Constants.DataTypes.VarChar);
            builder.Property(p => p.ShotDose).IsRequired().HasColumnType(Constants.DataTypes.Float);
            builder.Property(p => p.ShotNumber).IsRequired().HasColumnType(Constants.DataTypes.Integer);
            base.Configure(builder);
        }
    }
}
