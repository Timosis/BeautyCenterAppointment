using BeautyCenter.Common.Utils;
using BeautyCenter.Data.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Types.Dto.Payment
{
    public class PaymentDto
    {

        public int Id { get; set; }

        [JsonConverter(typeof(DateTimeFormatHelper), "dd/MM/yyyy HH:mm")]
        public DateTime PaymentDate { get; set; }

        public PaymentType PaymentType { get; set; }

        public double PaymentAmount { get; set; }

    }
}
