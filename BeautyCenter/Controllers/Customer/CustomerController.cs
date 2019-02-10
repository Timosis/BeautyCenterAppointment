using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Models;
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

        public IActionResult Customer_Update()
        {
            return PartialView("~/Views/Customer/UpdateCustomerPartial.cshtml");
        }

        public IActionResult Customers_Read()
        {
            List<CustomerVm> customers = new List<CustomerVm>()
            {
                new CustomerVm(1,GenerateRandomDateTime.GenerateStartDate(),"Tümer","Seyrek","tumerseyrek@outlook.com","05418409594"),
                new CustomerVm(2,GenerateRandomDateTime.GenerateStartDate(),"Kemal","Seyrek","kemal@kemal.com","43208943884"),
                new CustomerVm(3,GenerateRandomDateTime.GenerateStartDate(),"Taner","Seyrek","taner@taner.com","42394872349"),
                new CustomerVm(4,GenerateRandomDateTime.GenerateStartDate(),"Sezen","Seyrek","sezen@sezen.com","42349823094"),
                new CustomerVm(5,GenerateRandomDateTime.GenerateStartDate(),"Serkan","Türkoğlu","serkan@serkan.com","092384992038"),

            };           
            return Json(customers);
        }

        [AcceptVerbs("Post")]
        public ActionResult Customer_Create(CustomerVm customer)
        {
         
            CustomerVm newCustomer = new CustomerVm(1, GenerateRandomDateTime.GenerateStartDate(), customer.Firstname, customer.Lastname, customer.Email, customer.Telephone);

            return Json(new[] { newCustomer });
        }

        [AcceptVerbs("Post")]
        public ActionResult Customer_Update(CustomerVm customer)
        {
            CustomerVm newCustomer = new CustomerVm(1, GenerateRandomDateTime.GenerateStartDate(), customer.Firstname, customer.Lastname, customer.Email, customer.Telephone);
            
            return Json(new[] { newCustomer });
        }

        [AcceptVerbs("Post")]
        public ActionResult Customer_Destroy(CustomerVm customer)
        {
            CustomerVm newCustomer = new CustomerVm(1,GenerateRandomDateTime.GenerateStartDate(), customer.Firstname, customer.Lastname, customer.Email, customer.Telephone);

            return Json(new[] { newCustomer });
        }

        public IActionResult CustomerDetail()
        {
            return View("~/Views/Customer/CustomerDetail.cshtml");
        }

        public IActionResult CustomerAppointments_Read()
        {
            DateTime time = new DateTime(2018, 4, 21,12,38,45);
            
            List<CustomerAppointmentsVm> customers = new List<CustomerAppointmentsVm>()
            {
                new CustomerAppointmentsVm(1,time,"Epilasyon",Status.came),
                new CustomerAppointmentsVm(2,time,"Epilasyon",Status.canceled),
                new CustomerAppointmentsVm(3,time,"Epilasyon",Status.came),
                new CustomerAppointmentsVm(4,time,"Epilasyon",Status.canceled),
                new CustomerAppointmentsVm(5,time,"Epilasyon",Status.came)
            };
            return Json(customers);
        }

        public IActionResult CustomerOperations_Read()
        {
            DateTime time = new DateTime(2018, 4, 21, 12, 38, 45);


            List<CustomerOperationsVm> customerOperations = new List<CustomerOperationsVm>
            {
                new CustomerOperationsVm(1,time,"Lazer Epilasyon",5,200.45,true,true),
                new CustomerOperationsVm(2,time,"Lazer Epilasyon",6,200.45,true,true),
                new CustomerOperationsVm(3,time,"Lazer Epilasyon",7,200.45,true,true),
                new CustomerOperationsVm(3,time,"Lazer Epilasyon",8,200.45,true,true),
                new CustomerOperationsVm(3,time,"Lazer Epilasyon",9,200.45,true,true),
                new CustomerOperationsVm(3,time,"Lazer Epilasyon",10,200.45,true,true)
            };


            return Json(customerOperations);
        }

        public IActionResult CustomerInstallment_Read()
        {
            DateTime time = new DateTime(2018, 4, 21, 12, 38, 45);

            List<CustomerInstallmentVm> customerInstallments = new List<CustomerInstallmentVm>
            {
                new CustomerInstallmentVm(1,time,1,true),
                new CustomerInstallmentVm(2,time,2,true),
                new CustomerInstallmentVm(3,time,3,true),
                new CustomerInstallmentVm(4,time,4,false),
                new CustomerInstallmentVm(5,time,5,false),

            };
            return Json(customerInstallments);
        }

        public IActionResult CustomerPayments_Read()
        {
            DateTime time = new DateTime(2018, 4, 21, 12, 38, 45);

            List<CustomerPaymentsVm> customerPayments = new List<CustomerPaymentsVm>
            {
                new CustomerPaymentsVm(1,time,PaymentType.Cash,200.45),
                new CustomerPaymentsVm(2,time,PaymentType.BankOrCreditCard,320.45),
                new CustomerPaymentsVm(3,time,PaymentType.InstallmentToCreditCard,340.45),
                new CustomerPaymentsVm(4,time,PaymentType.InstallmentToDeliveryByHand,540.45),
                new CustomerPaymentsVm(5,time,PaymentType.Cash,640.45),
            };

            return Json(customerPayments);
        }

        public JsonResult GetCustomers(string text)
        {
           List<CustomerVm> customers = new List<CustomerVm>()
            {
                new CustomerVm(1,GenerateRandomDateTime.GenerateStartDate(),"Tümer","Seyrek","tumerseyrek@outlook.com","05418409594"),
                new CustomerVm(2,GenerateRandomDateTime.GenerateStartDate(),"Kemal","Seyrek","kemal@kemal.com","43208943884"),
                new CustomerVm(3,GenerateRandomDateTime.GenerateStartDate(),"Taner","Seyrek","taner@taner.com","42394872349"),
                new CustomerVm(4,GenerateRandomDateTime.GenerateStartDate(),"Sezen","Seyrek","sezen@sezen.com","42349823094"),
                new CustomerVm(5,GenerateRandomDateTime.GenerateStartDate(),"Serkan","Türkoğlu","serkan@serkan.com","092384992038"),
            };

            if (!string.IsNullOrEmpty(text))
            {
                customers = customers.Where(p => p.Firstname.Contains(text)).ToList();
            }
            return Json(customers);
        }
    }
}