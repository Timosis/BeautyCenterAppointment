using BeautyCenter.Common.Infra.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Commands.Customer
{
    public class GetAllCustomersCommand : BaseCommand, ICommand
    {
        public override string ValidateCommand()
        {
            return string.Empty;

        }
    }
}
