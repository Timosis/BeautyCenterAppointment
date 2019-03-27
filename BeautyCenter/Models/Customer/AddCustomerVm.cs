using BeautyCenter.Common.Types.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class AddCustomerVm
    {
        public CustomerDto Customer { get; set; }

        public AddCustomerVm()
        {
            Customer = new CustomerDto();
        }
    }
}
