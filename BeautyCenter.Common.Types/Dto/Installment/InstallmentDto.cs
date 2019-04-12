using BeautyCenter.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Types.Dto.Installment
{
    public class InstallmentDto
    {
        public int Id { get; set; }

        [JsonConverter(typeof(DateTimeFormatHelper), "dd/MM/yyyy HH:mm")]
        public DateTime InstallmentDate { get; set; }

        public int InstallmentCount { get; set; }

        public bool IsPaid { get; set; }

        public double TotalAmount { get; set; }

    }
}
