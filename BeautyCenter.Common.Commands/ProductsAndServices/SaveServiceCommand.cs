using BeautyCenter.Common.Infra;
using BeautyCenter.Common.Infra.Command;
using BeautyCenter.Common.Types.Dto.ProductsAndServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Commands.ProductsAndServices
{
    public class SaveServiceCommand : BaseCommand, ICommand
    {
        public ServiceDto Service { get; set; }

        public override string ValidateCommand()
        {
            if (Service == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (string.IsNullOrWhiteSpace(Service.Name))
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (Service.Duration == 0)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (Service.Amount == 0)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;
                       
            return string.Empty;
        }
    }
}
