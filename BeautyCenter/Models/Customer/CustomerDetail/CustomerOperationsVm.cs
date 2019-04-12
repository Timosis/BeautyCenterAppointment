using BeautyCenter.Common.Types.Dto.Customer;
using BeautyCenter.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer.CustomerDetail
{
    public class CustomerOperationsVm
    {
        public List<CustomerOperationsDto> CustomerOperations { get; set; }
       
        public CustomerOperationsVm()
        {
            CustomerOperations = new List<CustomerOperationsDto>();
        }
    }
}
