using BeautyCenter.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Identity
{
    public class RoleFunctionConfig : BaseConfig<RoleFunction>
    {
        public override void Configure(EntityTypeBuilder<RoleFunction> builder)
        {
            builder.ToTable(nameof(RoleFunction), Constants.Schemas.Identity);
            base.Configure(builder);
        }
    }
}
