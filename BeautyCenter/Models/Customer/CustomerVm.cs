﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerVm
    {

        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public CustomerVm(int CustomerId,string Firstname, string Lastname, string Email,string Telephone)
        {
            this.Id = CustomerId;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Email = Email;
            this.Telephone = Telephone;
        }




    }
}