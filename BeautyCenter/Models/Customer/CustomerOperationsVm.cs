using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerOperationsVm
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Department { get; set; }
        public int SessionCount { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public bool IsInstallment { get; set; }

        public CustomerOperationsVm(int id, DateTime date, string department, int sessionCount, decimal amount, bool isPaid, bool isInstallment)
        {
            this.Id = id;
            this.Date = date;
            this.Department = department;
            this.SessionCount = sessionCount;
            this.Amount = amount;
            this.IsPaid = isPaid;
            this.IsInstallment = isInstallment;
        }
    }
}
