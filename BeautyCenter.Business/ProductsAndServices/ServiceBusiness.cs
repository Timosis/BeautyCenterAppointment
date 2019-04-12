using AutoMapper;
using BeautyCenter.BusinessDomain.ProductsAndServices;
using BeautyCenter.Common.Commands.ProductsAndServices;
using BeautyCenter.Common.Infra;
using BeautyCenter.Common.Infra.Command;
using BeautyCenter.Common.Types.Dto.ProductsAndServices;
using BeautyCenter.Data.DataService.ProductsAndServices;
using BeautyCenter.Data.Entities.ProductsAndServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Business.ProductsAndServices
{

    public interface IServiceBusiness
    {
        Task<CommandResponse<ServiceDto>> SaveService(SaveServiceCommand command);

        Task<CommandResponse<List<ServiceDto>>> GetAllServices(GetAllServicesCommand command);

        Task<CommandResponse<ServiceDto>> GetServiceById(GetServiceByIdCommand command);

        Task<CommandResponse<ServiceDto>> UpdateService(UpdateServiceCommand command);

        Task<CommandResponse> DeleteService(DeleteServiceCommand command);

    }

    public class ServiceBusiness : BaseBusiness, IServiceBusiness
    {
        private readonly IServiceDataService serviceDataService;

        public ServiceBusiness(IServiceDataService serviceDataService) :base()
        {
            this.serviceDataService = serviceDataService;
        }

        public async Task<CommandResponse<ServiceDto>> SaveService(SaveServiceCommand command)
        {
            CommandResponse<ServiceDto> response = new CommandResponse<ServiceDto>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            var service = ServiceDomain.Create(command.Service);
            try
            {
                service = await serviceDataService.AddAsync(service);
            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.Customer_Common_ErrorOccuredWhileAddingCustomer, ex);
            }

            return Ok(response, Mapper.Map<Service, ServiceDto>(service));
        }

        public async Task<CommandResponse<ServiceDto>> UpdateService(UpdateServiceCommand command)
        {
            CommandResponse<ServiceDto> response = new CommandResponse<ServiceDto>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            if (command.Service.Id > 0)
            {
                var savedService = await serviceDataService.GetServiceById(command.Service.Id);
                if (savedService == null)
                {
                    return AppError(response, ErrorCodes.Customer_Common_CustomerNotFound);
                }

                ServiceDomain.Update(savedService, command.Service);
                try
                {
                    await serviceDataService.Update(savedService);
                }
                catch (Exception ex)
                {
                    return ServerError(response, ErrorCodes.Customer_Common_ErrorOccuredWhileUpdatingCustomer, ex);
                }

                return Ok(response, Mapper.Map<Service, ServiceDto>(savedService));
            }

            //TODO Uygun Bir Return bulunacak.
            return ServerError(response, ErrorCodes.Customer_Common_ErrorOccuredWhileUpdatingCustomer, null);
        }

        public async Task<CommandResponse<List<ServiceDto>>> GetAllServices(GetAllServicesCommand command)
        {
            CommandResponse<List<ServiceDto>> response = new CommandResponse<List<ServiceDto>>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            try
            {
                List<ServiceDto> list = new List<ServiceDto>();
                var result = await serviceDataService.GetAllServices();
                if (result?.Count > 0)
                {
                    result.ForEach(s =>
                    {
                        list.Add(new ServiceDto
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Duration = s.Duration,
                            Amount = s.Amount,
                            ColorClass = s.ColorClass
                        });
                    });
                }
                return Ok(response, list);
            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.Common_ErrorWhileGettingData, ex);
            }
        }

        public async Task<CommandResponse<ServiceDto>> GetServiceById(GetServiceByIdCommand command)
        {
            CommandResponse<ServiceDto> response = new CommandResponse<ServiceDto>(command);
            if (response.HasError)
            {
                return AppError(response, response.Code);
            }

            try
            {
                var service = await serviceDataService.GetServiceById(command.ServiceId);
                return Ok(response, Mapper.Map<ServiceDto>(service));

            }
            catch (Exception ex)
            {

                return ServerError(response, ErrorCodes.Common_ErrorOccuredWhileProcessingYourRequest, ex);
            }
        }

        public async Task<CommandResponse> DeleteService(DeleteServiceCommand command)
        {
            CommandResponse response = new CommandResponse(command);
            if (response.HasError)
                return AppError(response, response.Code);


            Service service;

            try
            {
                service = await serviceDataService.GetServiceById(command.ServiceId);

                if (service == null)
                {
                    return AppError(response, ErrorCodes.Service_TheServiceYouWantToDeleteWasNotFound);
                }
            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.Common_ErrorWhileGettingData, ex);
            }

            try
            {
                ServiceDomain.Delete(service);
                await serviceDataService.Update(service);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return ServerError(response, ErrorCodes.Common_ErrorOccuredWhileProcessingYourRequest, ex);
            }
        }
    }
}
