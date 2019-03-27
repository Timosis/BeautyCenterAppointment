using BeautyCenter.Common.Infra.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Installments
{
    public class Installment : Entity
    {
        
        public DateTime InstallmentDate { get; set; }

        public bool IsPaid { get; set; }

        public double TotalAmount { get; set; }
       
        public List<InstallmentDetail> InstallmentDetails { get; set; }

    }
}
