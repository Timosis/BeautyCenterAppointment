using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCenter.Controllers.Report
{
    public class TaxReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}