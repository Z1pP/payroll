using Microsoft.AspNetCore.Mvc;
using Payroll.Business.Services;

namespace Payroll.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public HomeController(EmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var listEmployees = _employeeService.GetEmployees();

            return View(listEmployees);
        }

    }
}