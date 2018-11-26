using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}