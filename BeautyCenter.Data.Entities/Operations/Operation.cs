using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Entities.Customers;
using BeautyCenter.Data.Entities.Enums;
using BeautyCenter.Data.Entities.ProductsAndServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Operations
{
    public class Operation : Entity
    {                
        public DateTime Datetime { get; set; }        
        public double Amount { get; set; }
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }


        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<OperationDetail> OperationDetails { get; set; }
    }
}
