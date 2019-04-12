using BeautyCenter.Common.Infra;
using BeautyCenter.Common.Infra.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Commands.Installment
{
    public class GetCustomerInstallmentCommand : BaseCommand, ICommand
    {

        public int? CustomerId { get; set; }


        public override string ValidateCommand()
        {
            if (CustomerId == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            return string.Empty;
        }
    }
}
