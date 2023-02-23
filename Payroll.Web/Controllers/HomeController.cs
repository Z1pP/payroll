using Microsoft.AspNetCore.Mvc;
using Payroll.Business.Services;
using Payroll.DataAccess.Models;
using Payroll.Web.Models;

namespace Payroll.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeService _employeeService;
        public HomeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index(Employee employee)
        {
            var listEmployees = _employeeService.GetEmployees();

            var employeeModel = new EmployeeViewModel
            {
                Employee = employee,
                Employees = listEmployees
            };

            return View(employeeModel);
        }
    }
}
