using AutoMapper;
using BeautyCenter.Common.Types.Dto.Appointment;
using BeautyCenter.Common.Types.Dto.Customer;
using BeautyCenter.Common.Types.Dto.ProductsAndServices;
using BeautyCenter.Data.Entities.Appointments;
using BeautyCenter.Data.Entities.Customers;
using BeautyCenter.Data.Entities.ProductsAndServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Service, ServiceDto>().ReverseMap();
        }
    }
}
