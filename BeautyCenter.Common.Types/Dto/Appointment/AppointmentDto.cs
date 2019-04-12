using BeautyCenter.Common.Types.Dto.Customer;
using BeautyCenter.Common.Types.Dto.ProductsAndServices;
using BeautyCenter.Common.Utils;
using Newtonsoft.Json;
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
        public string Description { get; set; }
        public int MyProperty { get; set; }



        public int ServiceId { get; set; }

        public ServiceDto Service { get; set; }

        public int CustomerId { get; set; }

        public CustomerDto Customer { get; set; }
    }
}
