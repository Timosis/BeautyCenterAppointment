using AutoMapper;
using BeautyCenter.BusinessDomain.Customers;
using BeautyCenter.Common.Commands.Customer;
using BeautyCenter.Common.Commands.Customer.CustomerDetail;
using BeautyCenter.Common.Infra;
using BeautyCenter.Common.Infra.Command;
using BeautyCenter.Common.Types.Dto.Customer;
using BeautyCenter.Data.DataService.Customers;
using BeautyCenter.Data.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Business.Customers
{

    public interface ICustomerBusiness
    {
        Task<CommandResponse<CustomerDto>> SaveCustomer(SaveCustomerCommand command);

        Task<CommandResponse<List<CustomerDto>>> GetAllCustomers(GetAllCustomersCommand command);

        Task<CommandResponse<CustomerDto>> GetCustomerById(GetCustomerByIdCommand command);

        Task<CommandResponse<CustomerDto>> UpdateCustomer(UpdateCustomerCommand command);

        Task<CommandResponse> DeleteCustomer(DeleteCustomerCommand command);

        Task<CommandResponse<List<CustomerDto>>> CustomerSearchByText(CustomerSearchCommand command);

        Task<CommandResponse<CustomerDetailDto>> GetCustomerDetail(GetCustomerDetailCommand command);

        Task<CommandResponse<List<CustomerAppointmentsDto>>> GetCustomerAppoinments(GetCustomerAppointmentCommand command);

        Task<CommandResponse<List<CustomerOperationsDto>>> GetCustomerOperations(GetCustomerOperationsCommand command);

    }

    public class CustomerBusiness : BaseBusiness, ICustomerBusiness
    {
        private readonly ICustomerDataService customerDataService;

        public CustomerBusiness(ICustomerDataService customerDataService) : base()
        {
            this.customerDataService = customerDataService;
        }

        public async Task<CommandResponse<List<CustomerDto>>> GetAllCustomers(GetAllCustomersCommand command)
        {
            CommandResponse<List<CustomerDto>> response = new CommandResponse<List<CustomerDto>>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            try
            {
                List<CustomerDto> list = new List<CustomerDto>();
                var result = await customerDataService.GetAllCustomers();
                if (result?.Count > 0)
                {
                    result.ForEach(c =>
                    {
                        list.Add(new CustomerDto
                        {
                            Id = c.Id,
                            Firstname = c.Firstname,
                            Lastname = c.Lastname,
                            Email = c.Email,
                            Telephone = c.Telephone,
                            RegisteredDate = c.RegisteredDate
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

        public async Task<CommandResponse<CustomerDto>> SaveCustomer(SaveCustomerCommand command)
        {
            CommandResponse<CustomerDto> response = new CommandResponse<CustomerDto>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            var customer = CustomerDomain.Create(command.Customer);
            var isCustomerExists = await customerDataService.IsCustomerExistsWithEmail(customer.Email);
            if (isCustomerExists)
            {
                return AppError(response, ErrorCodes.Customer_Common_CustomerAlreadyExistWithEmailAdress);
            }
            try
            {
                customer = await customerDataService.Add(customer);
            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.Customer_Common_ErrorOccuredWhileAddingCustomer, ex);
            }

            return Ok(response, Mapper.Map<Customer, CustomerDto>(customer));
        }

        public async Task<CommandResponse<CustomerDto>> GetCustomerById(GetCustomerByIdCommand command)
        {
            CommandResponse<CustomerDto> response = new CommandResponse<CustomerDto>(command);
            if (response.HasError)
            {
                return AppError(response, response.Code);
            }

            try
            {
                var customer = await customerDataService.GetCustomerById(command.CustomerId);
                return Ok(response, Mapper.Map<CustomerDto>(customer));

            }
            catch (Exception ex)
            {

                return ServerError(response, ErrorCodes.Common_ErrorOccuredWhileProcessingYourRequest, ex);
            }
        }

        public async Task<CommandResponse<CustomerDto>> UpdateCustomer(UpdateCustomerCommand command)
        {
            CommandResponse<CustomerDto> response = new CommandResponse<CustomerDto>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            if (command.Customer.Id > 0)
            {
                var savedCustomer = await customerDataService.GetCustomerById(command.Customer.Id);
                if (savedCustomer == null)
                {
                    return AppError(response, ErrorCodes.Customer_Common_CustomerNotFound);
                }

                CustomerDomain.Update(savedCustomer, command.Customer);
                try
                {
                    await customerDataService.Update(savedCustomer);
                }
                catch (Exception ex)
                {
                    return ServerError(response, ErrorCodes.Customer_Common_ErrorOccuredWhileUpdatingCustomer, ex);
                }

                return Ok(response, Mapper.Map<Customer, CustomerDto>(savedCustomer));
            }

            //TODO Uygun Bir Return bulunacak.
            return ServerError(response, ErrorCodes.Customer_Common_ErrorOccuredWhileUpdatingCustomer,null);
        }

        public async Task<CommandResponse> DeleteCustomer(DeleteCustomerCommand command)
        {
            CommandResponse response = new CommandResponse(command);
            if (response.HasError)
                return AppError(response, response.Code);

            Customer customer;

            try
            {
               customer = await customerDataService.GetCustomerById(command.CustomerId);

                if (customer == null)
                {
                   return AppError(response, ErrorCodes.Customer_TheCustomerYouWantToDeleteWasNotFound);
                }
            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.Common_ErrorWhileGettingData, ex);
            }
            
            try
            {
                CustomerDomain.Delete(customer);
                await customerDataService.Update(customer);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return ServerError(response, ErrorCodes.Common_ErrorOccuredWhileProcessingYourRequest, ex);
            }
        }

        public async Task<CommandResponse<List<CustomerDto>>> CustomerSearchByText(CustomerSearchCommand command)
        {
            CommandResponse<List<CustomerDto>> response = new CommandResponse<List<CustomerDto>>(command);
            if (response.HasError)
                AppError(response, response.Code);

            try
            {
                List<CustomerDto> customers = new List<CustomerDto>();
                var result = await customerDataService.GetCustomersByText(command.SearchText);
                if (result.Count > 0)
                {
                    result.ForEach(c =>
                    {
                        customers.Add(new CustomerDto
                        {
                            Id = c.Id,
                            Firstname = c.Firstname,
                            Lastname = c.Lastname,
                            Email = c.Email,
                            Telephone = c.Telephone,
                            RegisteredDate = c.RegisteredDate
                        });
                    });
                }

                return Ok(response, customers);
            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.Common_ErrorWhileGettingData, ex);
            }
        }

        public async Task<CommandResponse<CustomerDetailDto>> GetCustomerDetail(GetCustomerDetailCommand command)
        {
            CommandResponse<CustomerDetailDto> response = new CommandResponse<CustomerDetailDto>(command);
            if (response.HasError)
                AppError(response, response.Code);

            try
            {
                var result = await customerDataService.GetCustomerDetail(command.CustomerId);
                return Ok(response,result);
            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.Common_ErrorWhileGettingData, ex);
            }
        }

        public async Task<CommandResponse<List<CustomerAppointmentsDto>>> GetCustomerAppoinments(GetCustomerAppointmentCommand command)
        {
            CommandResponse<List<CustomerAppointmentsDto>> response = new CommandResponse<List<CustomerAppointmentsDto>>(command);
            if (response.HasError)
                AppError(response, response.Code);

            try
            {
                List<CustomerAppointmentsDto> customerAppointments = new List<CustomerAppointmentsDto>();
                var result = await customerDataService.GetCustomerAppointments(command.CustomerId);
                if (result.Count > 0)
                {
                    result.ForEach(a => {

                        customerAppointments.Add(new CustomerAppointmentsDto
                        {
                            Id = a.Id,
                            AppointmentDate = a.StartTime,
                            Service = a.Service.Name,
                            AppointmentStatus = a.AppointmentStatus
                        });

                    });
                }

                return Ok(response, customerAppointments);

            }
            catch (Exception ex)
            {

               return ServerError(response, ErrorCodes.Common_ErrorWhileGettingData, ex);
            }          
        }

        public async Task<CommandResponse<List<CustomerOperationsDto>>> GetCustomerOperations(GetCustomerOperationsCommand command)
        {
            CommandResponse<List<CustomerOperationsDto>> response = new CommandResponse<List<CustomerOperationsDto>>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            try
            {
                List<CustomerOperationsDto> customerOperations = new List<CustomerOperationsDto>();
                var result = await customerDataService.GetCustomerOperations(command.CustomerId);

                if (result.Count > 0)
                {
                    result.ForEach(c => {

                        customerOperations.Add(new CustomerOperationsDto
                        {
                                Id = c.Id,
                                OperationDate = c.Datetime,
                                Amount = c.Amount,
                                IsPaid = c.IsPaid,
                                Service = c.Service.Name,
                                PaymentType = c.PaymentType,
                                SeanceCount = c.OperationDetails.Count()                                
                        });
                    });
                }

                return Ok(response, customerOperations);
            }
            catch (Exception ex)
            {

                return ServerError(response, ErrorCodes.Common_ErrorWhileGettingData, ex);
            }
        }
    }
}
