using BeautyCenter.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Identity
{
    public class TwoFactorAuthConfig : BaseConfig <TwoFactorAuth>
    {
        public override void Configure(EntityTypeBuilder<TwoFactorAuth> builder)
        {
            builder.ToTable(nameof(TwoFactorAuth), Constants.Schemas.Identity);
            base.Configure(builder);
        }
    }
}
