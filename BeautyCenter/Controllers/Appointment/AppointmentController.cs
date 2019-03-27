using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Business.Appointments;
using BeautyCenter.Common.Commands.Appointment;
using BeautyCenter.Models;
using BeautyCenter.Models.Appointment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BeautyCenter.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentBusiness _appointmentBusiness;

        public AppointmentController(IAppointmentBusiness appointmentBusiness)
        {
            _appointmentBusiness = appointmentBusiness;
        }

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

         
            return Json(null);
        }

        public async Task<IActionResult> Appointment_Create(AddAppointmentVm vm)
        {
            var result = await _appointmentBusiness.SaveAppointment(new SaveAppointmentCommand
            {
                Appointment = vm.Appointment                              
            });

            if (result.HasError)
            {
                return Json("Başarısız!");
            }

            return Json("Başarılı");
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