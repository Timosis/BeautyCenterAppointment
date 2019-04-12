using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer.CustomerDetail
{
    public class CustomerDetailVm
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public double TotalOperationPrice { get; set; }
        public double TotalPaid { get; set; }
        public double TotalUnpaid { get; set; }        
    }
}
