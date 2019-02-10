using BeautyCenter.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerInstallmentVm
    {
        public int Id { get; set; }

        [JsonConverter(typeof(DateTimeFormatHelper), "dd/MM/yyyy HH:mm")]
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
