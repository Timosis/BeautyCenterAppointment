using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models
{
    public class AppointmentVm 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Color { get; set; }
        public bool IsFullDay { get; set; }


        public AppointmentVm(int Id,string Title,DateTime Start,DateTime End,string Color,bool IsFullDay)
        {
            this.Id = Id;
            this.Title = Title;
            this.Start = Start;
            this.End = End;
            this.Color = Color;
            this.IsFullDay = IsFullDay;
        }
    }
}
