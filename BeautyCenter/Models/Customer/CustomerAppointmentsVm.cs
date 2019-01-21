using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerAppointmentsVm
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Department { get; set; }

       public Status Status { get; set; }

        public CustomerAppointmentsVm(int id,DateTime appointmentdate,string department,Status status)
        {
            this.Id = id;
            this.AppointmentDate = appointmentdate;
            this.Department = department;
            this.Status = status;
        }
    }

    public enum Status
    {
        canceled = 1,
        came = 2
    }
}
