using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCenter.Controllers.Report
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExpenseReport()
        {
            return View();
        }

        public IActionResult IncomeExpenseBalanceReport()
        {
            return View();
        }

        public IActionResult IncomeReport()
        {
            return View();
        }

        public IActionResult TaxReport()
        {
            return View();
        }


        public IActionResult ProfitAndLoss()
        {
            return View();
        }


    }
}