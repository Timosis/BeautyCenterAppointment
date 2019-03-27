using BeautyCenter.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerOperationsVm
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public CustomerVm customer;  

        [JsonConverter(typeof(DateTimeFormatHelper), "dd/MM/yyyy HH:mm")]
        public DateTime Date { get; set; }
        public string Department { get; set; }
        public int SessionCount { get; set; }
        public double Amount { get; set; }
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }

        public List<CustomerOperationDetailVm> CustomerOperationDetails { get; set; }


        public CustomerOperationsVm(int id, int customerId, DateTime date, string department, int sessionCount, double amount, bool isPaid, PaymentType paymentType)
        {
            this.Id = id;
            this.Date = date;
            this.Department = department;
            this.SessionCount = sessionCount;
            this.Amount = amount;
            this.IsPaid = isPaid;
            this.PaymentType = paymentType;
            this.CustomerId = customerId;

        }
    }
}
