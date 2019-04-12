using BeautyCenter.Common.Infra;
using BeautyCenter.Common.Infra.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Commands.Operation
{
    public class GetCustomerOperationDetailsCommand : BaseCommand, ICommand
    {
        public int? OperationId { get; set; }

        public override string ValidateCommand()
        {
            if (OperationId == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            return string.Empty;
        }
    }
}
