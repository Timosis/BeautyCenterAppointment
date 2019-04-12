using BeautyCenter.Common.Infra;
using BeautyCenter.Common.Infra.Command;
using BeautyCenter.Common.Types.Dto.Appointment;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Commands.Appointment
{
    public class SaveAppointmentCommand : BaseCommand,ICommand
    {
        public AppointmentDto Appointment { get; set; }
                
        public override string ValidateCommand()
        {
            if (Appointment.CustomerId == 0)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;
            
            return string.Empty;
        }
    }
}
