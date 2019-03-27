using BeautyCenter.Data.Entities.Appointments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Data.DataService.Appointments
{

    public interface IAppointmentDataService
    {
        Task<Appointment> Add(Appointment appointment);

    }

    public class AppointmentDataService : BaseDataService, IAppointmentDataService
    {
        public Task<Appointment> Add(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
