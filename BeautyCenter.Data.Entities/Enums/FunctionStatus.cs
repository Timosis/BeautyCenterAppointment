﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeautyCenter.Data.Entities.Enums
{
    public enum FunctionStatus : byte
    {
        [Description("Aktif")]
        Active = 1,
        [Description("Pasif")]
        Passive = 2
    }
}
