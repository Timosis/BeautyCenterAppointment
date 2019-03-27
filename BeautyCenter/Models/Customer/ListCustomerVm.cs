using BeautyCenter.Common.Types.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class ListCustomerVm
    {
        public List<CustomerDto> Customers { get; set; }

        public ListCustomerVm()
        {
            Customers = new List<CustomerDto>();
        }
    }
}
