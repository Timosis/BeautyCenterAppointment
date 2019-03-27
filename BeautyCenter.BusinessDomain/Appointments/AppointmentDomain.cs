using System;
using System.Collections.Generic;
using System.Text;
using BeautyCenter.Common.Types.Dto.Appointment;
using BeautyCenter.Data.Entities.Appointments;

namespace BeautyCenter.BusinessDomain.Appointments
{
    public class AppointmentDomain
    {
        public static Appointment Create(AppointmentDto appointmentDto)
        {
            var appointment = new Data.Entities.Appointments.Appointment();

            appointment.Title = appointmentDto.Title;
            appointment.StartTime = appointmentDto.StartTime;
            appointment.EndTime = appointmentDto.EndTime;
            appointment.IsFullDay = appointmentDto.IsFullDay;
            appointment.Color = appointmentDto.Color;
            appointment.CustomerId = appointmentDto.CustomerId;

            return appointment;
        }
    }
}
