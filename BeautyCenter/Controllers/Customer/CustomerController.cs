using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeautyCenter.Business.Customers;
using BeautyCenter.Business.Installments;
using BeautyCenter.Business.Operation;
using BeautyCenter.Business.Payment;
using BeautyCenter.Common.Commands.Customer;
using BeautyCenter.Common.Commands.Customer.CustomerDetail;
using BeautyCenter.Common.Commands.Installment;
using BeautyCenter.Common.Commands.Operation;
using BeautyCenter.Common.Commands.Payment;
using BeautyCenter.Models.Customer;
using BeautyCenter.Models.Customer.CustomerDetail;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BeautyCenter.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerBusiness customerBusiness;
        private readonly IToastNotification toastNotificationService;
        private readonly IInstallmentBusiness installmentBusiness;
        private readonly IOperationsBusiness operationsBusiness;
        private readonly IPaymentBusiness paymentBusiness;


        public CustomerController(ICustomerBusiness customerBusiness, IInstallmentBusiness installmentBusiness, IOperationsBusiness operationsBusiness,
            IPaymentBusiness paymentBusiness, IToastNotification toastNotificationService)
        {
            this.customerBusiness = customerBusiness;
            this.toastNotificationService = toastNotificationService;
            this.installmentBusiness = installmentBusiness;
            this.paymentBusiness = paymentBusiness;
            this.operationsBusiness = operationsBusiness;
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

        [HttpPost]
        public async Task<ActionResult> Customer_Create(AddCustomerVm vm)
        {                  
            var result = await customerBusiness.SaveCustomer(new SaveCustomerCommand
            {
                Customer = vm.Customer
            });

            if (result.HasError)
            {
                toastNotificationService.AddErrorToastMessage(result.GetErrorMessage());
                return RedirectToAction("Index", "Customer");
            }

            toastNotificationService.AddSuccessToastMessage("İşleminiz Başarıyla Gerçekleştirildi");

            return RedirectToAction("Index", "Customer");
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

        public async Task<IActionResult> CustomerDetail(int customerId)
        {
            var customerDetail = await customerBusiness.GetCustomerDetail(new GetCustomerDetailCommand {
                CustomerId = customerId
            });
            CustomerDetailVm vm = new CustomerDetailVm();

            vm.Id = customerDetail.Result.Id;
            vm.Fullname = customerDetail.Result.Fullname;
            vm.Email = customerDetail.Result.Email;
            vm.Telephone = customerDetail.Result.Telephone;
            vm.TotalOperationPrice = customerDetail.Result.TotalOperationPrice;
            vm.TotalPaid = customerDetail.Result.TotalPaid;
            vm.TotalUnpaid = customerDetail.Result.TotalUnpaid;

            return View("~/Views/Customer/CustomerDetail.cshtml",vm);
        }

        public async Task<ActionResult> CustomerAppointments_Read(int customerId)
        {

            var customerAppointmentsResult = await customerBusiness.GetCustomerAppoinments(new GetCustomerAppointmentCommand
            {
                CustomerId = customerId
            });

            List<CustomerAppointmentsVm> vm = new List<CustomerAppointmentsVm>();

            foreach (var item in customerAppointmentsResult.Result)
            {
                vm.Add(new CustomerAppointmentsVm {

                    Id = item.Id,
                    AppointmentDate = item.AppointmentDate,
                    AppointmentStatus = item.AppointmentStatus,
                    Service = item.Service
                });
            }
            
            return Json(vm);
        }

        public async Task<JsonResult> CustomerOperations_Read(int customerId)
        {
            var result = await customerBusiness.GetCustomerOperations(new GetCustomerOperationsCommand
            {
                CustomerId = customerId
            });

            CustomerOperationsVm vm = new CustomerOperationsVm();
            vm.CustomerOperations = result.Result;

            return Json(vm.CustomerOperations);
        }

        public async Task<ActionResult> CustomerOperationDetail_Read(int customerOperationId)
        {
            var result = await operationsBusiness.GetCustomerOperationDetails(new GetCustomerOperationDetailsCommand {

                OperationId = customerOperationId
            });

            CustomerOperationDetailsVm vm = new CustomerOperationDetailsVm();

            vm.CustomerOperationDetails = result.Result;

            return PartialView("~/Views/Customer/OperationDetailsPartial.cshtml",vm);
        }

        public async Task<IActionResult> CustomerInstallment_Read(int customerId)
        {
            CustomerInstallmentVm vm = new CustomerInstallmentVm();

            var result = await installmentBusiness.GetCustomerInstallment(new GetCustomerInstallmentCommand {
                CustomerId = customerId
            });

            vm.CustomerInstallments = result.Result;
            
            return Json(vm.CustomerInstallments);
        }

        public IActionResult CustomerInstallmentDetail_Read(int customerInstallmentId)
        {

            return Json(null);
        }

        public async Task<IActionResult> CustomerPayments_Read(int customerId)
        {
            CustomerPaymentsVm vm = new CustomerPaymentsVm();

            var result = await paymentBusiness.GetCustomerPayment(new GetCustomerPaymentCommand
            {
                CustomerId = customerId
            });

            vm.CustomerPayments = result.Result;

            return Json(vm.CustomerPayments);
        }

        public async Task<ActionResult> CustomerSearch(string text)
        {
            CustomerSearchListVm customerSearchListVm = new CustomerSearchListVm();

            var customersResult = await customerBusiness.CustomerSearchByText(new CustomerSearchCommand
            {
                SearchText = text
            });

            if (customersResult.HasError)
            {
                toastNotificationService.AddErrorToastMessage(customersResult.GetErrorMessage());
                return RedirectToAction("Index", "Appointment");
            }
            return Json(customersResult.Result);
        }
    }
}