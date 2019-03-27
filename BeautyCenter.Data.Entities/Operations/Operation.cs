using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Operations
{
    public class Operation : Entity
    {                
        public DateTime Datetime { get; set; }
        public string Department { get; set; }        
        public double Amount { get; set; }
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }

        public List<OperationDetail> OperationDetails { get; set; }
    }
}
