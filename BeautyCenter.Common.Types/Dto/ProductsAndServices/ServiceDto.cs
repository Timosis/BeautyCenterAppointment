using BeautyCenter.Common.Types.Dto.Appointment;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Types.Dto.ProductsAndServices
{
    public class ServiceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public decimal Amount { get; set; }

        public string ColorClass { get; set; }
    }
}
