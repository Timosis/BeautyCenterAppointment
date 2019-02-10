using BeautyCenter.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerVm
    {

        public int Id { get; set; }

        [JsonConverter(typeof(DateTimeFormatHelper), "dd/MM/yyyy HH:mm")]
        public DateTime RegisteredDate { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public CustomerVm(int CustomerId,DateTime RegisteredDate,string Firstname, string Lastname, string Email,string Telephone)
        {
            this.Id = CustomerId;
            this.RegisteredDate = RegisteredDate;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Email = Email;
            this.Telephone = Telephone;
        }
    }
}
