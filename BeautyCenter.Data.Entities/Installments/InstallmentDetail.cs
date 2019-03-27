using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Installments
{
    public class InstallmentDetail : Entity
    {        
        public DateTime InstallmentDate { get; set; }

        public double Amount { get; set; }

        public PaymentState PaymentState { get; set; }

        public Installment Installment { get; set; }
    }
}
