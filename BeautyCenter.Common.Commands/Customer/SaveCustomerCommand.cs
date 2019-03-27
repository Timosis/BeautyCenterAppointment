using BeautyCenter.Common.Infra;
using BeautyCenter.Common.Infra.Command;
using BeautyCenter.Common.Types.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Commands.Customer
{
    public class SaveCustomerCommand : BaseCommand,ICommand
    {
        public CustomerDto Customer { get; set; }

        public override string ValidateCommand()
        {
            if (Customer == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (string.IsNullOrWhiteSpace(Customer.Firstname))
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (string.IsNullOrWhiteSpace(Customer.Lastname))
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (string.IsNullOrWhiteSpace(Customer.Email))
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (string.IsNullOrWhiteSpace(Customer.Telephone))
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            //TODO Appointment'ın diğer alanlarının validasyonları yazılacak!
            return string.Empty;
        }
    }
}
