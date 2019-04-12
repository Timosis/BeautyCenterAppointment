using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Types.Dto.Customer
{
    public class CustomerDetailDto
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
