using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Entities.Appointments;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.ProductsAndServices
{
    public class Service:Entity
    {
        public string Name { get; set; }

        public int Duration { get; set; }

        public decimal Amount { get; set; }

        public string ColorClass { get; set; }

    }
}
