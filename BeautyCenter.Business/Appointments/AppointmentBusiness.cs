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
using BeautyCenter.Common.Types.Dto.ProductsAndServices;

namespace BeautyCenter.Business.Appointments
{
    public interface IAppointmentBusiness
    {
        Task<CommandResponse<AppointmentDto>> SaveAppointment(SaveAppointmentCommand command);

        Task<CommandResponse<List<AppointmentDto>>> GetAllAppointments(GetAllAppointmentsCommand command);

    }

    public class AppointmentBusiness : BaseBusiness, IAppointmentBusiness
    {
        private readonly IAppointmentDataService appointmentDataService;

        public AppointmentBusiness(IAppointmentDataService appointmentDataService) : base()
        {
            this.appointmentDataService = appointmentDataService;     
        }

        public async Task<CommandResponse<List<AppointmentDto>>> GetAllAppointments(GetAllAppointmentsCommand command)
        {
            CommandResponse<List<AppointmentDto>> response = new CommandResponse<List<AppointmentDto>>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            try
            {
                List<AppointmentDto> appointments = new List<AppointmentDto>();
                var result = await appointmentDataService.GetAllAppointments();

                if (result.Count > 0)
                {
                    result.ForEach(a =>
                    {
                        appointments.Add(new AppointmentDto
                        {
                            CustomerId = a.CustomerId,
                            Color = a.Color,
                            Description = a.Description,
                            StartTime = a.StartTime,
                            EndTime = a.EndTime,
                            Id = a.Id,
                            IsFullDay = a.IsFullDay,
                            Title = a.Title,
                            ServiceId = a.ServiceId,
                            Service = new ServiceDto {
                                Id = a.Service.Id,
                                Name = a.Service.Name,
                                Duration = a.Service.Duration,
                                Amount = a.Service.Amount,
                                ColorClass = a.Service.ColorClass
                            }
                        });
                    });
                }
                return Ok(response, appointments);

            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.Common_ErrorWhileGettingData, ex);
            }
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