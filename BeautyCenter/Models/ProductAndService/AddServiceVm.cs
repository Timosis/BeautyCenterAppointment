using BeautyCenter.Common.Types.Dto.ProductsAndServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.ProductAndService
{
    public class AddServiceVm
    {
        public ServiceDto Service { get; set; }

        public AddServiceVm()
        {
            Service = new ServiceDto();
        }
    }
}
