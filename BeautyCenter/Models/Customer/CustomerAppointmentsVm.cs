using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeautyCenter.Common.Utils;
using Newtonsoft.Json;

namespace BeautyCenter.Models.Customer
{
    public class CustomerAppointmentsVm
    {
        public int Id { get; set; }

        [JsonConverter(typeof(DateTimeFormatHelper), "dd/MM/yyyy HH:mm")]
        public DateTime AppointmentDate { get; set; }

        public string Operation { get; set; }

       public Status Status { get; set; }

        public CustomerAppointmentsVm(int id,DateTime appointmentdate,string operation, Status status)
        {
            this.Id = id;
            this.AppointmentDate = appointmentdate;
            this.Operation = operation;
            this.Status = status;
        }
    }

    public enum Status
    {
        canceled = 1,
        came = 2
    }
}
