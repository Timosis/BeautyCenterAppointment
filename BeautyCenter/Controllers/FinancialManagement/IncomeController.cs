using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCenter.Controllers.FinancialManagement
{
    public class IncomeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/FinancialManagement/Income/Index.cshtml");
        }

        public IActionResult Bills()
        {
            return View("~/Views/FinancialManagement/Income/Bills.cshtml");
        }

        public IActionResult Collections()
        {
            return View("~/Views/FinancialManagement/Income/Collections.cshtml");
        }
    }
}