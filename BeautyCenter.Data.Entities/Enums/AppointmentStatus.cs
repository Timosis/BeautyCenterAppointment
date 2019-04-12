using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeautyCenter.Data.Entities.Enums
{
    public enum AppointmentStatus
    {
        [Description("İptal")]
        Canceled = 1,
        [Description("Geldi")]
        Came = 2,
        [Description("Active")]
        Active = 3
    }
}
