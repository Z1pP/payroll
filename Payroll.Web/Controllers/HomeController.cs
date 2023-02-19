using Microsoft.AspNetCore.Mvc;
using Payroll.Web.Models;
using System.Diagnostics;

namespace Payroll.Web.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}