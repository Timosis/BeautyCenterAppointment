using BeautyCenter.Common.Types.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerSearchListVm
    {
        public List<CustomerDto> Customers { get; set; }

        public CustomerSearchListVm()
        {
            Customers = new List<CustomerDto>();
        }
    }
}
