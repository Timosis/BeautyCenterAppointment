using BeautyCenter.Common.Commands.Installment;
using BeautyCenter.Common.Infra;
using BeautyCenter.Common.Infra.Command;
using BeautyCenter.Common.Types.Dto.Installment;
using BeautyCenter.Data.DataService.Installments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Business.Installments
{
    public interface IInstallmentBusiness
    {
        Task<CommandResponse<List<InstallmentDto>>> GetCustomerInstallment(GetCustomerInstallmentCommand command);
    }

    public class InstallmentBusiness : BaseBusiness,IInstallmentBusiness
    {
       private readonly IInstallmentDataService customerDataService;

       public InstallmentBusiness(IInstallmentDataService customerDataService)
        {
            this.customerDataService = customerDataService;
        }

        public async Task<CommandResponse<List<InstallmentDto>>> GetCustomerInstallment(GetCustomerInstallmentCommand command)
        {
            CommandResponse<List<InstallmentDto>> response = new CommandResponse<List<InstallmentDto>>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            try
            {
                List<InstallmentDto> customerInstallments = new List<InstallmentDto>();
                var result = await customerDataService.GetCustomerInstallments(command.CustomerId);

                if (result.Count > 0)
                {
                    result.ForEach(c =>
                    {
                        customerInstallments.Add(new InstallmentDto
                        {
                            Id = c.Id,
                            InstallmentDate = c.InstallmentDate,
                            IsPaid = c.IsPaid,
                            TotalAmount = c.TotalAmount,
                            InstallmentCount = c.InstallmentDetails.Count()
                        });
                    });
                }

                return Ok(response, customerInstallments);

            }
            catch (Exception ex)
            {

                return ServerError(response, ErrorCodes.Common_ErrorWhileGettingData, ex);
            }
        }
    }
}
