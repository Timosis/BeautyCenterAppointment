using BeautyCenter.Common.Types.Dto.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models
{
    public class AppointmentVm 
    {
        AppointmentDto Appointment { get; set; }

        public AppointmentVm()
        {
            Appointment = new AppointmentDto();
        }
    }
}
