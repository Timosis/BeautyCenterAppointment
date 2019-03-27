using System;
using System.Collections.Generic;
using System.Text;

using AutoMapper;
using BeautyCenter.BusinessDomain.Appointments;
using BeautyCenter.Common.Commands.Appointment;
using BeautyCenter.Common.Infra.Command;
using BeautyCenter.Common.Infra.Logger;
using BeautyCenter.Common.Types.Dto.Appointment;
using BeautyCenter.Data.DataService.Appointments;
using BeautyCenter.Data.Entities.Appointments;
using System.Threading.Tasks;
using BeautyCenter.Common.Infra;

namespace BeautyCenter.Business.Appointments
{
    public interface IAppointmentBusiness
    {
        Task<CommandResponse<AppointmentDto>> SaveAppointment(SaveAppointmentCommand command);
    }

    public class AppointmentBusiness : BaseBusiness, IAppointmentBusiness
    {
        private readonly IAppointmentDataService appointmentDataService;

        public AppointmentBusiness(IAppointmentDataService appointmentDataService) : base()
        {
            this.appointmentDataService = appointmentDataService;     
        }

        public async Task<CommandResponse<AppointmentDto>> SaveAppointment(SaveAppointmentCommand command)
        {
            CommandResponse<AppointmentDto> response = new CommandResponse<AppointmentDto>(command);
            if (response.HasError)
                return AppError(response, response.Code);
        
            var appointment = AppointmentDomain.Create(command.Appointment);


            try
            {
                appointment = await appointmentDataService.Add(appointment);
            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.Customer_Common_ErrorOccuredWhileAddingCustomer, ex);
            }

            return Ok(response, Mapper.Map<Appointment,AppointmentDto >(appointment));

        }
    }


}