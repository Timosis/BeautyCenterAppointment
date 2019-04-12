using BeautyCenter.Common.Types.Dto.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer.CustomerDetail
{
    public class CustomerOperationDetailsVm
    {
        public List<OperationDetailsDto> CustomerOperationDetails { get; set; }

        public CustomerOperationDetailsVm()
        {
            CustomerOperationDetails = new List<OperationDetailsDto>();
        }
    }
}
