using BeautyCenter.Common.Types.Dto.Payment;
using BeautyCenter.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerPaymentsVm
    {
        public List<PaymentDto> CustomerPayments { get; set; }

        public CustomerPaymentsVm()
        {
            CustomerPayments = new List<PaymentDto>();
        }

    }

}
