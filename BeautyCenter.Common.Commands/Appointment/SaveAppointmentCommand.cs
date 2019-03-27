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
            if (Appointment == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (string.IsNullOrWhiteSpace(Appointment.Title))
                return ErrorCodes.Common_PleaseFillAllRequiredFields;
            
            //TODO Appointment'ın diğer alanlarının validasyonları yazılacak!

            return string.Empty;
        }
    }
}
