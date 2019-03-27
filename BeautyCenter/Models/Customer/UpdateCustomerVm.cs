using BeautyCenter.Common.Types.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class UpdateCustomerVm
    {
        public CustomerDto Customer { get; set; }

        public UpdateCustomerVm()
        {
            Customer = new CustomerDto();
        }
    }
}
