using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Business.Customers;
using BeautyCenter.Common.Commands.Customer;
using BeautyCenter.Models;
using BeautyCenter.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BeautyCenter.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerBusiness customerBusiness;
        private readonly IToastNotification toastNotificationService;

        public CustomerController(ICustomerBusiness customerBusiness, IToastNotification toastNotificationService)
        {
            this.customerBusiness = customerBusiness;
            this.toastNotificationService = toastNotificationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Customer_Add()
        {
            return PartialView("~/Views/Customer/AddCustomerPartial.cshtml");
        }

        public async Task<ActionResult> Customer_Update(int customerId)
        {
            UpdateCustomerVm vm = new UpdateCustomerVm();
            var result = await customerBusiness.GetCustomerById(
                    new GetCustomerByIdCommand {

                        CustomerId = customerId
                    });

            if (result.HasError)
            {
                toastNotificationService.AddErrorToastMessage(result.GetErrorMessage());
                return PartialView("~/Views/Customer/UpdateCustomerPartial.cshtml");
            }

            vm.Customer.Id = result.Result.Id;
            vm.Customer.Firstname = result.Result.Firstname;
            vm.Customer.Lastname = result.Result.Lastname;
            vm.Customer.Email = result.Result.Email;
            vm.Customer.Telephone = result.Result.Telephone;

            return PartialView("~/Views/Customer/UpdateCustomerPartial.cshtml",vm);
        }

        [HttpPost]
        public async Task<ActionResult> Customer_Update(UpdateCustomerVm updateCustomerVm)
        {
            var result = await customerBusiness.UpdateCustomer(new UpdateCustomerCommand
            {
                Customer = updateCustomerVm.Customer
            });

            if (result.HasError)
            {
                toastNotificationService.AddErrorToastMessage(result.GetErrorMessage());
                return View("~/Views/Customer/Index.cshtml");
            }

            toastNotificationService.AddSuccessToastMessage("İşleminiz Başarıyla Gerçekleştirildi");

            return View("~/Views/Customer/Index.cshtml");
        }

        public async Task<ActionResult> Customers_Read()
        {
            ListCustomerVm customerVm = new ListCustomerVm();

            var customersResult = await customerBusiness.GetAllCustomers(new GetAllCustomersCommand());

            if (customersResult.HasError)
            {
                toastNotificationService.AddErrorToastMessage(customersResult.GetErrorMessage());
                return RedirectToAction("Index", "Home");
            }

            customerVm.Customers = customersResult.Result;

            return Json(customerVm.Customers);
        }

        public async Task<ActionResult> Customer_Create(AddCustomerVm vm)
        {                  
            var result = await customerBusiness.SaveCustomer(new SaveCustomerCommand
            {
                Customer = vm.Customer
            });

            if (result.HasError)
            {
                toastNotificationService.AddErrorToastMessage(result.GetErrorMessage());
                return View("~/Views/Customer/Index.cshtml");
            }

            toastNotificationService.AddSuccessToastMessage("İşleminiz Başarıyla Gerçekleştirildi");
          
            return View("~/Views/Customer/Index.cshtml");
        }

        [AcceptVerbs("Post")]
        public async Task<ActionResult> Customer_Delete(int customerId)
        {
            var result = await customerBusiness.DeleteCustomer(new DeleteCustomerCommand
            {
                CustomerId = customerId
            });

            if (result.HasError)
            {
                toastNotificationService.AddErrorToastMessage(result.GetErrorMessage());
                return View("~/Views/Customer/Index.cshtml");

            }

            return View("~/Views/Customer/Index.cshtml");
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
                new CustomerAppointmentsVm(1,time,"Epilasyon",Status.Came),
                new CustomerAppointmentsVm(2,time,"Epilasyon",Status.Canceled),
                new CustomerAppointmentsVm(3,time,"Epilasyon",Status.Came),
                new CustomerAppointmentsVm(4,time,"Epilasyon",Status.Canceled),
                new CustomerAppointmentsVm(5,time,"Epilasyon",Status.Came),
                new CustomerAppointmentsVm(6,time,"Epilasyon",Status.Active),
                new CustomerAppointmentsVm(7,time,"Epilasyon",Status.Active)
            };
            return Json(customers);
        }

        public IActionResult CustomerOperations_Read()
        {
            DateTime time = new DateTime(2018, 4, 21, 12, 38, 45);


            List<CustomerOperationsVm> customerOperations = new List<CustomerOperationsVm>
            {
                new CustomerOperationsVm(1,1,time,"Lazer Epilasyon",5,200.45,true,PaymentType.BankOrCreditCard),
                new CustomerOperationsVm(2,1,time,"Lazer Epilasyon",6,200.45,true,PaymentType.Cash),
                new CustomerOperationsVm(3,1,time,"Lazer Epilasyon",7,200.45,true,PaymentType.Cash),
                new CustomerOperationsVm(4,1,time,"Lazer Epilasyon",8,200.45,true,PaymentType.InstallmentToCreditCard),
                new CustomerOperationsVm(5,1,time,"Lazer Epilasyon",9,200.45,true,PaymentType.InstallmentToCreditCard),
                new CustomerOperationsVm(6,1,time,"Lazer Epilasyon",10,200.45,true,PaymentType.InstallmentToDeliveryByHand),
                new CustomerOperationsVm(7,1,time,"Lazer Epilasyon",10,200.45,true,PaymentType.InstallmentToDeliveryByHand),
                new CustomerOperationsVm(8,1,time,"Lazer Epilasyon",10,200.45,true,PaymentType.InstallmentToDeliveryByHand)
            };

            return Json(customerOperations);
        }

        public IActionResult CustomerOperationDetail_Read(int customerOperationId)
        {

            // get CustomerOperationDetail where CustomerOperationDetail.CustomerOperation = Id

            DateTime time = new DateTime(2018, 4, 21, 12, 38, 45);

            //List<CustomerOperationsVm> customerOperations = new List<CustomerOperationsVm>
            //{




            //};


            CustomerOperationsVm customerOperations = new CustomerOperationsVm(1,1,time,"deneme",2,3,true,PaymentType.Cash)
            {
                customer = new CustomerVm(1,time,"Tümer","Seyrek","tumer.seyrek@outlook.com","5418409594"),
                CustomerOperationDetails = new List<CustomerOperationDetailVm> {
                    new CustomerOperationDetailVm(1,1,SeanceType.Control,time,"Deneme 1", "Body 1", 20,40),
                    new CustomerOperationDetailVm(2,1,SeanceType.Control,time,"Deneme 2", "Body 2", 30,40),
                    new CustomerOperationDetailVm(3,1,SeanceType.Control,time,"Deneme 3", "Body 3", 40,40),
                    new CustomerOperationDetailVm(4,1,SeanceType.Control,time,"Deneme 4", "Body 4", 50,40),
                    new CustomerOperationDetailVm(5,1,SeanceType.Control,time,"Deneme 5", "Body 5", 60,40),
                }
                
            };

            List<CustomerOperationDetailVm> operationDetailsFirst = new List<CustomerOperationDetailVm>
            {
                new CustomerOperationDetailVm(1,1,SeanceType.Normal,time,"Seans 1","Body",20,40),
                new CustomerOperationDetailVm(2,1,SeanceType.Normal,time,"Seans 2","Body",30,50),
                new CustomerOperationDetailVm(3,1,SeanceType.Normal,time,"Seans 3","Body",40,60),
                new CustomerOperationDetailVm(4,1,SeanceType.Normal,time,"Seans 4","Body",50,70),
                new CustomerOperationDetailVm(5,1,SeanceType.Normal,time,"Seans 4","Body",60,80)
            };

            List<CustomerOperationDetailVm> operationDetailsSecond = new List<CustomerOperationDetailVm>
            {
                new CustomerOperationDetailVm(1,2,SeanceType.Normal,time,"Seans 1","Body",20,40),
                new CustomerOperationDetailVm(2,2,SeanceType.Normal,time,"Seans 2","Body",30,50),
                new CustomerOperationDetailVm(3,2,SeanceType.Normal,time,"Seans 3","Body",40,60),
                new CustomerOperationDetailVm(4,2,SeanceType.Normal,time,"Seans 4","Body",50,70),
                new CustomerOperationDetailVm(5,2,SeanceType.Normal,time,"Seans 5","Body",60,80),
                new CustomerOperationDetailVm(1,2,SeanceType.Normal,time,"Seans 6","Body",20,40)

            };

            List<CustomerOperationDetailVm> operationDetailsThird = new List<CustomerOperationDetailVm>
            {
                new CustomerOperationDetailVm(1,3,SeanceType.Normal,time,"Seans 1","Body",20,40),
                new CustomerOperationDetailVm(2,3,SeanceType.Normal,time,"Seans 2","Body",30,50),
                new CustomerOperationDetailVm(3,3,SeanceType.Normal,time,"Seans 3","Body",40,60),
                new CustomerOperationDetailVm(4,3,SeanceType.Normal,time,"Seans 4","Body",50,70),
                new CustomerOperationDetailVm(5,3,SeanceType.Normal,time,"Seans 5","Body",60,80),
                new CustomerOperationDetailVm(6,3,SeanceType.Normal,time,"Seans 6","Body",60,80),
                new CustomerOperationDetailVm(7,3,SeanceType.Normal,time,"Seans 7","Body",60,80)

            };

            List<CustomerOperationDetailVm> operationDetailsFourth = new List<CustomerOperationDetailVm>
            {
                new CustomerOperationDetailVm(1,4,SeanceType.Normal,time,"Seans 1","Body",20,40),
                new CustomerOperationDetailVm(2,4,SeanceType.Normal,time,"Seans 2","Body",30,50),
                new CustomerOperationDetailVm(3,4,SeanceType.Normal,time,"Seans 3","Body",40,60),
                new CustomerOperationDetailVm(4,4,SeanceType.Normal,time,"Seans 4","Body",50,70),
                new CustomerOperationDetailVm(5,4,SeanceType.Normal,time,"Seans 4","Body",60,80)
            };

            List<CustomerOperationDetailVm> operationDetailsFifth = new List<CustomerOperationDetailVm>
            {
                new CustomerOperationDetailVm(1,5,SeanceType.Normal,time,"Seans 1","Body",20,40),
                new CustomerOperationDetailVm(2,5,SeanceType.Normal,time,"Seans 2","Body",30,50),
                new CustomerOperationDetailVm(3,5,SeanceType.Normal,time,"Seans 3","Body",40,60),
                new CustomerOperationDetailVm(4,6,SeanceType.Normal,time,"Seans 4","Body",50,70),
                new CustomerOperationDetailVm(5,7,SeanceType.Normal,time,"Seans 4","Body",60,80)
            };

            return Json(operationDetailsFirst);
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

        //public async Task<ActionResult> GetCustomers(string text)
        //{
        //   List<CustomerVm> customers = new List<CustomerVm>()
        //    {
        //        new CustomerVm(1,GenerateRandomDateTime.GenerateStartDate(),"Tümer","Seyrek","tumerseyrek@outlook.com","05418409594"),
        //        new CustomerVm(2,GenerateRandomDateTime.GenerateStartDate(),"Kemal","Seyrek","kemal@kemal.com","43208943884"),
        //        new CustomerVm(3,GenerateRandomDateTime.GenerateStartDate(),"Taner","Seyrek","taner@taner.com","42394872349"),
        //        new CustomerVm(4,GenerateRandomDateTime.GenerateStartDate(),"Sezen","Seyrek","sezen@sezen.com","42349823094"),
        //        new CustomerVm(5,GenerateRandomDateTime.GenerateStartDate(),"Serkan","Türkoğlu","serkan@serkan.com","092384992038"),
        //    };

        //    if (!string.IsNullOrEmpty(text))
        //    {
        //        customers = customers.Where(p => p.Firstname.Contains(text)).ToList();
        //    }
        //    return Json(customers);
        //}
    }
}