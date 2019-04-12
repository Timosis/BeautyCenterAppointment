using BeautyCenter.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Types.Dto.Customer
{
    public class CustomerAppointmentsDto
    {
        public int Id { get; set; }
        public DateTime AppointmentDate  { get; set; }
        public string Service { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public PaymentType Payment { get; set; }
    }
}
