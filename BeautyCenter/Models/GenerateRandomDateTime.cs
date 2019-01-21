using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models
{
    public static class GenerateRandomDateTime
    {
        public static DateTime StartDate { get; set; }

        public static DateTime EndDate { get; set; }


        public static DateTime GenerateStartDate()
        {
            Random random = new Random();
            StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, random.Next(1, 30), random.Next(9, 18), random.Next(0, 60), random.Next(0, 60));
            return StartDate; 
        }

        public static DateTime GenerateEndDate()
        {
            if (StartDate != null)
            {
                EndDate = StartDate.AddMinutes(30);
            }
            
            return EndDate;
        }


    }
}
