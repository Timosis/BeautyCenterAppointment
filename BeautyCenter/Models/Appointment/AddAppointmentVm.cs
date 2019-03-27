using BeautyCenter.Common.Types.Dto.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Appointment
{
    public class AddAppointmentVm
    {
        public AppointmentDto Appointment { get; set; }

        public AddAppointmentVm()
        {
            Appointment = new AppointmentDto();
        }
    }
}
