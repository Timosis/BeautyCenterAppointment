using BeautyCenter.Common.Types.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Types.Dto.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Color { get; set; }
        public bool IsFullDay { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }


        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
