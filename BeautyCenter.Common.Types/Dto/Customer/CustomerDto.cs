using BeautyCenter.Common.Types.Dto.Appointment;
using BeautyCenter.Common.Types.Dto.Installment;
using BeautyCenter.Common.Types.Dto.Operation;
using BeautyCenter.Common.Types.Dto.Payment;
using BeautyCenter.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Types.Dto.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [JsonConverter(typeof(DateTimeFormatHelper), "dd/MM/yyyy HH:mm")]
        public DateTime RegisteredDate { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

    }
}
