using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerInstallmentDetailVm
    {
        public int Id { get; set; }

        public DateTime InstallmentDate { get; set; }

        public double Amount { get; set; }

        public PaymentState PaymentState { get; set; }

        public int CustomerInstallmentDetailId { get; set; }

        public CustomerInstallmentVm CustomerInstallmentVm { get; set; }


        public CustomerInstallmentDetailVm(int id, DateTime installmentDate, double amount, PaymentState paymentState)
        {
            this.Id = id;
            this.InstallmentDate = installmentDate;
            this.Amount = amount;
            this.PaymentState = paymentState;
        }
    }

    public enum PaymentState {

        Paid = 1,
        Waiting = 2,
        Passed = 3
    }

}
