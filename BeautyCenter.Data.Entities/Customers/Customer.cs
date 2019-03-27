using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Entities.Appointments;
using BeautyCenter.Data.Entities.Installments;
using BeautyCenter.Data.Entities.Operations;
using BeautyCenter.Data.Entities.Payments;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Customers
{
   public class Customer : Entity
    {
        public DateTime RegisteredDate { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public List<Appointment> Appointments { get; set; }

        public List<Installment> Installments { get; set; }

        public List<Operation>  Operations { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
