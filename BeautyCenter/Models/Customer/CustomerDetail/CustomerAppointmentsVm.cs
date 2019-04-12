using BeautyCenter.Common.Utils;
using BeautyCenter.Data.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer.CustomerDetail
{
    public class CustomerAppointmentsVm
    {
        public int Id { get; set; }
        [JsonConverter(typeof(DateTimeFormatHelper), "dd/MM/yyyy HH:mm")]
        public DateTime AppointmentDate { get; set; }
        public string Service { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }

    }
}
