using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerPaymentsVm
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public PaymentType PaymentType { get; set; }

        public decimal PaymentAmount { get; set; }


        public CustomerPaymentsVm(int id, DateTime dateTime, PaymentType paymentType, decimal paymentAmount)
        {
            this.Id = id;
            this.DateTime = dateTime;
            this.PaymentType = paymentType;
            this.PaymentAmount = paymentAmount;
        }

    }

    public enum PaymentType
    {
        cash = 1,
        Card = 2
    }

}
