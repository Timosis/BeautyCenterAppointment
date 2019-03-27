using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Entities.Customers;
using BeautyCenter.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Payments
{
    public class Payment : Entity
    {
        public DateTime PaymentDate { get; set; }

        public PaymentType PaymentType { get; set; }

        public double PaymentAmount { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
