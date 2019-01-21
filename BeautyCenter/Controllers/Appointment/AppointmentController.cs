using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BeautyCenter.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointment_Add()
        {
            return PartialView("~/Views/Appointment/AddAppointmentPartial.cshtml");

        }

        public IActionResult Appointment_Read()
        {          

            List<AppointmentVm> appointments = new List<AppointmentVm>() {

                new AppointmentVm(1,"Sulayman Christian",GenerateRandomDateTime.GenerateStartDate(),GenerateRandomDateTime.GenerateEndDate(),"Blue",false),
                new AppointmentVm(2,"Aarush Harrison",GenerateRandomDateTime.GenerateStartDate(),GenerateRandomDateTime.GenerateEndDate(),"Blue",false),
                new AppointmentVm(3,"Piper Tate",GenerateRandomDateTime.GenerateStartDate(),GenerateRandomDateTime.GenerateEndDate(),"Blue",false),
                new AppointmentVm(4,"Keanan Tran",GenerateRandomDateTime.GenerateStartDate(),GenerateRandomDateTime.GenerateEndDate(),"Blue",false),
                new AppointmentVm(5,"Kaiya Goodman",GenerateRandomDateTime.GenerateStartDate(),GenerateRandomDateTime.GenerateEndDate(),"Blue",false),
                new AppointmentVm(6,"Bradlee Logan",GenerateRandomDateTime.GenerateStartDate(),GenerateRandomDateTime.GenerateEndDate(),"Blue",false),
            };
           
            return Json(appointments);
        }

        public IActionResult Appointment_Create()
        {
            List<AppointmentVm> appointments = new List<AppointmentVm>();


            return Json(appointments);
        }

        public IActionResult Appointment_Update()
        {
            Random random = new Random();
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, random.Next(1, 30));
            List<AppointmentVm> appointments = new List<AppointmentVm>();


            return Json(appointments);
        }

        public IActionResult Appointment_Delete()
        {
            List<AppointmentVm> appointments = new List<AppointmentVm>();
            return Json(appointments);
        }    
    }
}