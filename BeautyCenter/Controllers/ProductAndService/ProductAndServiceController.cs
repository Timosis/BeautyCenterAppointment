using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Business.ProductsAndServices;
using BeautyCenter.Common.Commands.ProductsAndServices;
using BeautyCenter.Models.ProductAndService;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BeautyCenter.Controllers
{
    public class ProductAndServiceController : Controller
    {
        private readonly IServiceBusiness serviceBusiness;
        private readonly IToastNotification toastNotificationService;


        public ProductAndServiceController(IServiceBusiness serviceBusiness, IToastNotification toastNotificationService)
        {
            this.serviceBusiness = serviceBusiness;
            this.toastNotificationService = toastNotificationService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Service_Add()
        {
            return PartialView("~/Views/ProductAndService/AddServicePartial.cshtml");
        }


        public async Task<ActionResult> Service_Update(int serviceId)
        {
            UpdateServiceVm vm = new UpdateServiceVm();

            var result = await serviceBusiness.GetServiceById(
                        new GetServiceByIdCommand
                        {
                            ServiceId = serviceId
                        });

            if (result.HasError)
            {
                toastNotificationService.AddErrorToastMessage(result.GetErrorMessage());
                return PartialView("~/Views/ProductAndService/UpdateServicePartial.cshtml");
            }


            vm.Service.Id = result.Result.Id;
            vm.Service.Name = result.Result.Name;
            vm.Service.Duration = result.Result.Duration;
            vm.Service.Amount = result.Result.Amount;

            return PartialView("~/Views/ProductAndService/UpdateServicePartial.cshtml",vm);
        }

        [HttpPost]
        public async Task<ActionResult> Service_Update(UpdateServiceVm updateServiceVm)        
        {

            var result = await serviceBusiness.UpdateService(new UpdateServiceCommand
            {
                Service = updateServiceVm.Service
            });

            if (result.HasError)
            {
                toastNotificationService.AddErrorToastMessage(result.GetErrorMessage());
                return View("~/Views/ProductAndService/Index.cshtml");
            }

            toastNotificationService.AddSuccessToastMessage("İşleminiz Başarıyla Gerçekleştirildi");

            return View("~/Views/ProductAndService/Index.cshtml");
        }

        public async Task<ActionResult> Service_Read()
        {

            ListServiceVm customerVm = new ListServiceVm();

            var servicesResult = await serviceBusiness.GetAllServices(new GetAllServicesCommand());

            if (servicesResult.HasError)
            {
                toastNotificationService.AddErrorToastMessage(servicesResult.GetErrorMessage());
                return RedirectToAction("Index", "Home");
            }

            customerVm.Services = servicesResult.Result;

            return Json(customerVm.Services);
        }

        public async Task<ActionResult> Service_Create(AddServiceVm vm)
        {
            var result = await serviceBusiness.SaveService(new SaveServiceCommand
            {
                Service = vm.Service
            });

            if (result.HasError)
            {
                toastNotificationService.AddErrorToastMessage(result.GetErrorMessage());
                return View("~/Views/ProductAndService/Index.cshtml");
            }

            toastNotificationService.AddSuccessToastMessage("İşleminiz Başarıyla Gerçekleştirildi");

            return View("~/Views/ProductAndService/Index.cshtml");
        }

        [AcceptVerbs("Post")]
        public async Task<ActionResult> Service_Delete(int serviceId)
        {
            var result = await serviceBusiness.DeleteService(new DeleteServiceCommand
            {
                ServiceId = serviceId
            });

            if (result.HasError)
            {
                toastNotificationService.AddErrorToastMessage(result.GetErrorMessage());
                return View("~/Views/ProductAndService/Index.cshtml");
            }

            return View("~/Views/ProductAndService/Index.cshtml");
        }
    }
}