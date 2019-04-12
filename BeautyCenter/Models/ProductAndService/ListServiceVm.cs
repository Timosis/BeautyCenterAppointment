using BeautyCenter.Common.Types.Dto.ProductsAndServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.ProductAndService
{
    public class ListServiceVm
    {
        public List<ServiceDto> Services { get; set; }

        public ListServiceVm()
        {
            Services = new List<ServiceDto>();
        }
    }
}
