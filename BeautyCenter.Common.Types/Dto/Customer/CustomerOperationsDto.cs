using BeautyCenter.Common.Utils;
using BeautyCenter.Data.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Types.Dto.Customer
{
    public class CustomerOperationsDto
    {
        public int Id { get; set; }
        [JsonConverter(typeof(DateTimeFormatHelper), "dd/MM/yyyy HH:mm")]
        public DateTime OperationDate { get; set; }
        public string Service { get; set; }
        public double Amount { get; set; }
        public bool IsPaid { get; set; }
        public int SeanceCount { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
