using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeautyCenter.Data.Entities.Enums
{
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
