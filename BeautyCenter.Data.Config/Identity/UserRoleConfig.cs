using BeautyCenter.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Identity
{
    public class UserRoleConfig : BaseConfig<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(nameof(UserRole), Constants.Schemas.Identity);
            builder.HasOne(p => p.User).WithMany(p => p.UserRoles).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Role).WithMany(p => p.UserRoles).HasForeignKey(p => p.RoleId);

            base.Configure(builder);
        }
    }
}
