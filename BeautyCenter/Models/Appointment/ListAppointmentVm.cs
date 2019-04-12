using BeautyCenter.Common.Types.Dto.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Appointment
{
    public class ListAppointmentVm
    {

        public List<AppointmentDto> Appointments { get; set; }


        public ListAppointmentVm()
        {
            Appointments = new List<AppointmentDto>();
        }



    }
}
