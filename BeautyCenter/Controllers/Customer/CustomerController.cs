using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Models.Customer;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCenter.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Customer_Add()
        {
            return PartialView("~/Views/Customer/AddCustomerPartial.cshtml");
        }

        public IActionResult Customers_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<CustomerVm> customers = new List<CustomerVm>()
            {
                new CustomerVm(1,"Tümer","Seyrek","tumerseyrek@outlook.com","05418409594"),
                new CustomerVm(2,"Kemal","Seyrek","kemal@kemal.com","43208943884"),
                new CustomerVm(3,"Taner","Seyrek","taner@taner.com","42394872349"),
                new CustomerVm(4,"Sezen","Seyrek","sezen@sezen.com","42349823094"),
                new CustomerVm(5,"Serkan","Türkoğlu","serkan@serkan.com","092384992038"),

            };           
            return Json(customers.ToDataSourceResult(request));
        }

        [AcceptVerbs("Post")]
        public ActionResult Customer_Create([DataSourceRequest] DataSourceRequest request, CustomerVm customer)
        {
         
            CustomerVm newCustomer = new CustomerVm(1,customer.Firstname, customer.Lastname, customer.Email, customer.Telephone);

            return Json(new[] { newCustomer }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult Customer_Update([DataSourceRequest] DataSourceRequest request, CustomerVm customer)
        {
            CustomerVm newCustomer = new CustomerVm(1, customer.Firstname, customer.Lastname, customer.Email, customer.Telephone);
            
            return Json(new[] { newCustomer }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult Customer_Destroy([DataSourceRequest] DataSourceRequest request, CustomerVm customer)
        {
            CustomerVm newCustomer = new CustomerVm(1, customer.Firstname, customer.Lastname, customer.Email, customer.Telephone);

            return Json(new[] { newCustomer }.ToDataSourceResult(request, ModelState));
        }
    }
}