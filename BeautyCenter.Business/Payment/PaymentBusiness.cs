using BeautyCenter.Common.Commands.Payment;
using BeautyCenter.Common.Infra;
using BeautyCenter.Common.Infra.Command;
using BeautyCenter.Common.Types.Dto.Payment;
using BeautyCenter.Data.DataService.Payments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Business.Payment
{

    public interface IPaymentBusiness
    {
        Task<CommandResponse<List<PaymentDto>>> GetCustomerPayment(GetCustomerPaymentCommand command);
    }


    public class PaymentBusiness : BaseBusiness, IPaymentBusiness
    {
        private readonly IPaymentDataService customerDataService;

        public PaymentBusiness(IPaymentDataService customerDataService)
        {
            this.customerDataService = customerDataService;
        }

        public async Task<CommandResponse<List<PaymentDto>>> GetCustomerPayment(GetCustomerPaymentCommand command)
        {
            CommandResponse<List<PaymentDto>> response = new CommandResponse<List<PaymentDto>>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            try
            {
                List<PaymentDto> customerPayments = new List<PaymentDto>();
                var result = await customerDataService.GetCustomerPayments(command.CustomerId);

                if (result.Count > 0)
                {
                    result.ForEach(c =>
                    {
                        customerPayments.Add(new PaymentDto
                        {
                            Id = c.Id,
                            PaymentAmount = c.PaymentAmount,
                            PaymentDate = c.PaymentDate,
                            PaymentType = c.PaymentType
       
                        });
                    });
                }

                return Ok(response, customerPayments);

            }
            catch (Exception ex)
            {

                return ServerError(response, ErrorCodes.Common_ErrorWhileGettingData, ex);
            }



        }
    }
}
