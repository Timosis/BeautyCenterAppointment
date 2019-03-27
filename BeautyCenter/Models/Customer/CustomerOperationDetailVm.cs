using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models.Customer
{
    public class CustomerOperationDetailVm
    {
        public int Id { get; set; }

        public SeanceType SeanceType { get; set; }

        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        public string Area { get; set; }

        public double ShotDose { get; set; }

        public int ShotNumber { get; set; }

        public int CustomerOperationId { get; set; }

        public CustomerOperationsVm CustomerOperationsVm { get; set; }


        public CustomerOperationDetailVm(int id, int CustomerOperationId , SeanceType seanceType, DateTime dateTime, string description, string area, double shotDose, int shotNumber)
        {
            this.Id = id;
            this.SeanceType = seanceType;
            this.DateTime = dateTime;
            this.Description = description;
            this.Area = area;
            this.ShotDose = shotDose;
            this.ShotNumber = shotNumber;
            this.CustomerOperationId = CustomerOperationId;
        }
    }
    public enum SeanceType
    {
        Normal = 1,
        Control = 2
    }




}
