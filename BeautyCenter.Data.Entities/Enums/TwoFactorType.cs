using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeautyCenter.Data.Entities.Enums
{
    public enum TwoFactorType : byte
    {
        [Description("Telefon")]
        Phone = 1,
        [Description("Email")]
        Email = 2
    }
}
