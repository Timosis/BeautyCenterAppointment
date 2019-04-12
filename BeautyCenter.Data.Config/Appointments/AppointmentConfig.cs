using BeautyCenter.Data.Entities.Appointments;
using BeautyCenter.Data.Entities.ProductsAndServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Appointments
{
    public class AppointmentConfig : BaseConfig<Appointment>
    {
        public override void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable(nameof(Appointment),Constants.Schemas.Appointment);
            //builder.HasOne<Appointment>(s => s.Service).WithOne(ap => ap.Service).HasForeignKey<Service>(ap => ap.);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(150).HasColumnType(Constants.DataTypes.VarChar);
            builder.Property(p => p.StartTime).IsRequired().HasColumnType(Constants.DataTypes.Datetime);
            builder.Property(p => p.EndTime).IsRequired().HasColumnType(Constants.DataTypes.Datetime);
            builder.Property(p => p.Color).IsRequired().HasMaxLength(150).HasColumnType(Constants.DataTypes.VarChar);
            builder.Property(p => p.IsFullDay).IsRequired().HasColumnType(Constants.DataTypes.Bit);

            base.Configure(builder);
        }
    }
}
