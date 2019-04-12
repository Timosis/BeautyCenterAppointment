using BeautyCenter.Common.Infra;
using BeautyCenter.Common.Infra.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Commands.ProductsAndServices
{
    public class DeleteServiceCommand : BaseCommand, ICommand
    {
        public int? ServiceId { get; set; }

        public override string ValidateCommand()
        {
            if (ServiceId == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            return string.Empty;
        }
    }
}
