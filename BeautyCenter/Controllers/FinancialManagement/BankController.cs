using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Models.Bank;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCenter.Controllers.FinancialManagement
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/FinancialManagement/Bank/Index.cshtml");
        }

        public IActionResult Accounts()
        {
            return View("~/Views/FinancialManagement/Bank/Accounts.cshtml");
        }

        public IActionResult Transactions()
        {
            return View("~/Views/FinancialManagement/Bank/Accounts.cshtml");
        }

        public IActionResult Accounts_Read([DataSourceRequest] DataSourceRequest request)
        {

            decimal bankAmount = 250.789M;

            List<AccountVm> accounts = new List<AccountVm>()
            {
                new AccountVm(1,"İş Bankası",bankAmount),
                new AccountVm(2,"Ak Bank",bankAmount),
                new AccountVm(3,"Ziraat Bank",bankAmount),
                new AccountVm(4,"Garanti Bank",bankAmount)
            };
            return Json(accounts.ToDataSourceResult(request));
        }


        public IActionResult Accounts_Create([DataSourceRequest] DataSourceRequest request,AccountVm account)
        {

            decimal finansBank = 203.789M;

            AccountVm newAccount = new AccountVm(7,"Finans Bank", finansBank);
            
            return Json(new[] { newAccount }.ToDataSourceResult(request));
        }
    }
}