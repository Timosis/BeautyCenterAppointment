using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Entities.Customers;
using BeautyCenter.Data.Entities.Enums;
using BeautyCenter.Data.Entities.ProductsAndServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Appointments
{
    public class Appointment : Entity
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Color { get; set; }
        public bool IsFullDay { get; set; }
        public string Description { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }



        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
      
    }
}
