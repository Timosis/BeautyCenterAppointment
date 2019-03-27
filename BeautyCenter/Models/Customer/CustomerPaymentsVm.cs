using BeautyCenter.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerPaymentsVm
    {
        public int Id { get; set; }

        [JsonConverter(typeof(DateTimeFormatHelper), "dd/MM/yyyy HH:mm")]
        public DateTime PaymentDate { get; set; }

        public PaymentType PaymentType { get; set; }

        public double PaymentAmount { get; set; }

        public CustomerPaymentsVm(int id, DateTime paymentDate, PaymentType paymentType, double paymentAmount)
        {
            this.Id = id;
            this.PaymentDate = paymentDate;
            this.PaymentType = paymentType;
            this.PaymentAmount = paymentAmount;
        }
    }

    //TODO: Data.Entities katmanındaki PaymentType kullanılıp DTO'ların yapılandırılmasından sonra buradan kaldıracak
    public enum PaymentType
    {
        [Description("Nakit")]
        Cash = 1,
        [Description("Banka Veya Kredi Kartı")]
        BankOrCreditCard = 2,
        [Description("Kredi Kartına Taksit")]
        InstallmentToCreditCard = 3,
        [Description("Elden Taksit")]
        InstallmentToDeliveryByHand = 4
    }
}
