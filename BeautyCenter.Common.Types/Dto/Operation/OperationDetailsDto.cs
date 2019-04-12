using BeautyCenter.Common.Utils;
using BeautyCenter.Data.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Types.Dto.Operation
{
    public class OperationDetailsDto
    {
        public int Id { get; set; }

        public SeanceType SeanceType { get; set; }

        [JsonConverter(typeof(DateTimeFormatHelper), "dd/MM/yyyy HH:mm")]
        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        public string Area { get; set; }

        public double ShotDose { get; set; }

        public int ShotNumber { get; set; }

    }
}
