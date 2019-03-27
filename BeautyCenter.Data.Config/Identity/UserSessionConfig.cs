using BeautyCenter.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config.Identity
{
    public class UserSessionConfig : BaseConfig<UserSession>
    {
        public override void Configure(EntityTypeBuilder<UserSession> builder)
        {
            builder.ToTable(nameof(UserSession), Constants.Schemas.Identity);                       
            base.Configure(builder);
        }
    }
}
