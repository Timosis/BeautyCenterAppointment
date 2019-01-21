using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerInstallmentVm
    {
        public int Id { get; set; }

        public DateTime InstallmentDate { get; set; }

        public int InstallmentNumber { get; set; }
       
        public bool IsPaid { get; set; }


        public CustomerInstallmentVm(int id,DateTime installmentDate,int installmentNumber,bool isPaid)
        {
            this.Id = id;
            this.InstallmentDate = installmentDate;
            this.InstallmentNumber = installmentNumber;
            this.IsPaid = isPaid;
        }
    }
}
