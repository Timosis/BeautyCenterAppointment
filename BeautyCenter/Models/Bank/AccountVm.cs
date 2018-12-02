using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Bank
{
    public class AccountVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public AccountVm(int Id, string name,decimal amount)
        {
            this.Id = Id;
            this.Name = name;
            this.Amount = amount;
        }
    }
}
