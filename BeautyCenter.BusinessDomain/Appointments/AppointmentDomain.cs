using System;
using System.Collections.Generic;
using System.Text;
using BeautyCenter.Common.Types.Dto.Appointment;
using BeautyCenter.Data.Entities.Appointments;
using BeautyCenter.Data.Entities.Enums;

namespace BeautyCenter.BusinessDomain.Appointments
{
    public class AppointmentDomain
    {
        public static Appointment Create(AppointmentDto appointmentDto)
        {
            var appointment = new Data.Entities.Appointments.Appointment();

            appointment.Title = appointmentDto.Title;
            appointment.StartTime = appointmentDto.StartTime;
            appointment.EndTime = appointment.StartTime.AddMinutes(appointmentDto.Service.Duration);
            appointment.IsFullDay = appointmentDto.IsFullDay;
            appointment.Color = "Blue";
            appointment.ServiceId = appointmentDto.ServiceId;
            appointment.CustomerId = appointmentDto.CustomerId;
            appointment.CreatedAt = DateTime.Now;
            appointment.ModifiedAt = DateTime.Now;
            appointment.AppointmentStatus = AppointmentStatus.Active;

            return appointment;
        }
    }
}
