using BeautyCenter.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Identity
{
    public class ResetPasswordConfig : BaseConfig<ResetPassword>
    {
        public override void Configure(EntityTypeBuilder<ResetPassword> builder)
        {
            builder.ToTable(nameof(ResetPassword), Constants.Schemas.Identity);
            base.Configure(builder);
        }
    }
}
