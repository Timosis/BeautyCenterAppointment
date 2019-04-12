using BeautyCenter.Common.Types.Dto.Installment;
using BeautyCenter.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerInstallmentVm
    {
        public List<InstallmentDto> CustomerInstallments { get; set; }

        public CustomerInstallmentVm()
        {
            CustomerInstallments = new List<InstallmentDto>();
        }

    }
}
