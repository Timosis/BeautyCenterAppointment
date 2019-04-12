using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeautyCenter.Business.Appointments;
using BeautyCenter.Business.Customers;
using BeautyCenter.Business.ProductsAndServices;
using BeautyCenter.Common.Commands.Appointment;
using BeautyCenter.Common.Commands.Customer;
using BeautyCenter.Common.Commands.ProductsAndServices;
using BeautyCenter.Common.Types.Dto.ProductsAndServices;
using BeautyCenter.Models;
using BeautyCenter.Models.Appointment;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BeautyCenter.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentBusiness appointmentBusiness;
        private readonly IServiceBusiness serviceBusiness;
        private readonly IToastNotification toastNotificationService;
        private readonly ICustomerBusiness customerBusiness;


        public AppointmentController(IAppointmentBusiness appointmentBusiness,ICustomerBusiness customerBusiness, IServiceBusiness serviceBusiness, IToastNotification toastNotificationService)
        {
            this.appointmentBusiness = appointmentBusiness;
            this.toastNotificationService = toastNotificationService;
            this.serviceBusiness = serviceBusiness;
            this.customerBusiness = customerBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointment_Add()
        {
            return PartialView("~/Views/Appointment/AddAppointmentPartial.cshtml");
        }

        public IActionResult Appointment_NewCustomerTab()
        {
            return PartialView("~/Views/Appointment/AddAppointmentNewCustomerTab.cshtml");
        }

        public IActionResult Appointment_SavedCustomerTab()
        {
            return PartialView("~/Views/Appointment/AddAppointmentSavedCustomerTab.cshtml");
        }

        public async Task<IActionResult> Appointment_Read()
        {
            ListAppointmentVm appointmentVm = new ListAppointmentVm();

            var appointmentsResult = await appointmentBusiness.GetAllAppointments(new GetAllAppointmentsCommand());

            if (appointmentsResult.HasError)
            {
                toastNotificationService.AddErrorToastMessage(appointmentsResult.GetErrorMessage());
                return RedirectToAction("Index", "Appointment");
            }

            appointmentVm.Appointments = appointmentsResult.Result;


            return Json(appointmentVm.Appointments);
        }

        public async Task<IActionResult> Appointment_Create(AddAppointmentVm vm)
        {
            if (vm.Appointment.CustomerId > 0)
            {
                var customerResult = await customerBusiness.GetCustomerById(new GetCustomerByIdCommand
                {
                    CustomerId = vm.Appointment.CustomerId
                });

                if (customerResult.HasError)
                {
                    toastNotificationService.AddErrorToastMessage(customerResult.GetErrorMessage());
                    return View("~/Views/Appointment/Index.cshtml");
                }

                vm.Appointment.Title = customerResult.Result.Firstname + " " + customerResult.Result.Lastname;
            }
            else
            {
                var customerSaveResult = await customerBusiness.SaveCustomer(new SaveCustomerCommand
                {
                    Customer = vm.Appointment.Customer
                });

                vm.Appointment.Title = customerSaveResult.Result.Firstname + " " + customerSaveResult.Result.Lastname;
                vm.Appointment.CustomerId = customerSaveResult.Result.Id;
            }


            var serviceResult = await serviceBusiness.GetServiceById(new GetServiceByIdCommand
            {
                ServiceId = vm.Appointment.ServiceId
            });

            vm.Appointment.Service = new ServiceDto()
            {
                Id = serviceResult.Result.Id,
                Name = serviceResult.Result.Name,
                Duration = serviceResult.Result.Duration,
                Amount = serviceResult.Result.Amount
            };
        
            var result = await appointmentBusiness.SaveAppointment(new SaveAppointmentCommand
            {
                Appointment = vm.Appointment
               
            });

            if (result.HasError)
            {
                toastNotificationService.AddErrorToastMessage(result.GetErrorMessage());
                return View("~/Views/Appointment/Index.cshtml");
            }

            toastNotificationService.AddSuccessToastMessage("İşleminiz Başarıyla Gerçekleştirildi");
            return View("~/Views/Appointment/Index.cshtml");
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