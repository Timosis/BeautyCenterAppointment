﻿using BeautyCenter.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Identity
{
    public class RoleConfig : BaseConfig<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role), Constants.Schemas.Identity);
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired().HasColumnType(Constants.DataTypes.VarChar);
            builder.Property(p => p.UniqueName).HasMaxLength(100).IsRequired().HasColumnType(Constants.DataTypes.VarChar);
            builder.Property(p => p.Description).HasMaxLength(250).HasColumnType(Constants.DataTypes.VarChar);
            base.Configure(builder);
        }
    }
}
