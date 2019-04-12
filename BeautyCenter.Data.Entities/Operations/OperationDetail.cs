using BeautyCenter.Common.Infra.DataLayer.Entities;
using BeautyCenter.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Data.Entities.Operations
{
    public class OperationDetail : Entity
    {
        public SeanceType SeanceType { get; set; }

        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        public string Area { get; set; }

        public double ShotDose { get; set; }

        public int ShotNumber { get; set; }


        public int OperationId { get; set; }
        public Operation Operation { get; set; }
    }
}
