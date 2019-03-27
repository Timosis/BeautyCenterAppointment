using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Config
{
    internal class Constants
    {
        internal class Schemas
        {
            public const string Infra = "Infra";
            public const string Identity = "Identity";
            public const string Customer = "Customer";
            public const string Appointment = "Appointment";
            public const string Installment = "Installement";
            public const string Operation = "Operation";
            public const string Payment = "Payment";
            public const string Diciplinary = "Diciplinary";
        }

        internal class DataTypes
        {
            public const string VarChar = "varchar(150)";
            public const string Datetime = "datetime";
            public const string Bit = "bit";
            public const string Integer = "int";
            public const string Float = "float";
            public const string Decimal = "decimal";
        }
    }
}
