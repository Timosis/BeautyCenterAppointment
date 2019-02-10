using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Utils
{
    public class DateTimeFormatHelper : IsoDateTimeConverter
    {
        public DateTimeFormatHelper(string format)
        {
            DateTimeFormat = format;
        }
    }
}
