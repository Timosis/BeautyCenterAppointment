using BeautyCenter.Common.Types.Dto.ProductsAndServices;
using BeautyCenter.Data.Entities.ProductsAndServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.BusinessDomain.ProductsAndServices
{
    public class ServiceDomain
    {
        public static Service Create(ServiceDto serviceDto)
        {
            var service = new Service();

            service.Name = serviceDto.Name;
            service.Duration = serviceDto.Duration;
            service.Amount = serviceDto.Amount;
            service.CreatedAt = DateTime.Now;
            service.ModifiedAt = DateTime.Now;
            service.ColorClass = serviceDto.ColorClass;
            return service;
        }

        public static void Update(Service service, ServiceDto serviceDto)
        {
            service.Name = serviceDto.Name;
            service.Duration = serviceDto.Duration;
            service.Amount = serviceDto.Amount;
            service.ModifiedAt = DateTime.Now;
        }

        public static void Delete(Service service)
        {
            service.IsDeleted = true;
        }
    }
}
