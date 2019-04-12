using BeautyCenter.Common.Infra.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Commands.Appointment
{
    public class GetAllAppointmentsCommand : BaseCommand, ICommand
    {
        public override string ValidateCommand()
        {
            return string.Empty;
        }
    }
}
