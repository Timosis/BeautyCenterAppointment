using BeautyCenter.Common.Commands.Customer.CustomerDetail;
using BeautyCenter.Common.Commands.Operation;
using BeautyCenter.Common.Infra;
using BeautyCenter.Common.Infra.Command;
using BeautyCenter.Common.Types.Dto.Customer;
using BeautyCenter.Common.Types.Dto.Operation;
using BeautyCenter.Data.DataService.Operations;
using BeautyCenter.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Business.Operation
{

    public interface IOperationsBusiness
    {
        Task<CommandResponse<List<CustomerOperationsDto>>> GetCustomerOperations(GetCustomerOperationsCommand command);

        Task<CommandResponse<List<OperationDetailsDto>>> GetCustomerOperationDetails(GetCustomerOperationDetailsCommand command);

    }

    public class OperationBusiness:BaseBusiness,IOperationsBusiness
    {
        private readonly IOperationsDataService operationsDataService;

        public OperationBusiness(IOperationsDataService operationsDataService) : base()
        {
            this.operationsDataService = operationsDataService;
        }

        public async Task<CommandResponse<List<CustomerOperationsDto>>> GetCustomerOperations(GetCustomerOperationsCommand command)
        {
            CommandResponse<List<CustomerOperationsDto>> response = new CommandResponse<List<CustomerOperationsDto>>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            try
            {
                List<CustomerOperationsDto> customerOperations = new List<CustomerOperationsDto>();
                var result = await operationsDataService.GetCustomerOperations(command.CustomerId);

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


        public async Task<CommandResponse<List<OperationDetailsDto>>> GetCustomerOperationDetails(GetCustomerOperationDetailsCommand command)
        {
            CommandResponse<List<OperationDetailsDto>> response = new CommandResponse<List<OperationDetailsDto>>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            try
            {
                List<OperationDetailsDto> operationDetails = new List<OperationDetailsDto>();
                var result = await operationsDataService.GetCustomerOperationsDetail(command.OperationId);

                if (result.Count > 0)
                {
                    result.ForEach(d => {

                        operationDetails.Add(new OperationDetailsDto
                        {
                            Id = d.Id,
                            DateTime = d.DateTime,
                            Area = d.Area,
                            Description = d.Description,
                            SeanceType = d.SeanceType,
                            ShotDose = d.ShotDose,
                            ShotNumber = d.ShotNumber                   
                        });
                    });
                }

                return Ok(response, operationDetails);
            }
            catch (Exception ex)
            {

                return ServerError(response, ErrorCodes.Common_ErrorWhileGettingData, ex);
            }

        }
    }
}
