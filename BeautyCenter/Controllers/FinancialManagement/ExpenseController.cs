using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCenter.Controllers.FinancialManagement
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/FinancialManagement/Expense/Index.cshtml");
        }

        public IActionResult Bills()
        {
            return View("~/Views/FinancialManagement/Expense/Bills.cshtml");
        }

        public IActionResult Payments()
        {
            return View("~/Views/FinancialManagement/Expense/Payments.cshtml");
        }
    }
}