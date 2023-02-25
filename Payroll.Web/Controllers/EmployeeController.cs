using Microsoft.AspNetCore.Mvc;
using Payroll.Business.Services;
using Payroll.DataAccess.Models;

namespace Payroll.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ReportService _reportService;
        private readonly EmployeeService _employeeService;
        public EmployeeController(ReportService reportService, EmployeeService employeeService)
        {
            _reportService = reportService;
            _employeeService = employeeService;
        }


        public IActionResult Details(int employeeId)
        {
            var report = _reportService.GetReportForEmployeeById(employeeId);
            
            return View("Index",report);
        }

        [HttpPost]
        public IActionResult Remove(int employeeId)
        {
            HttpContext.Session.TryGetEmployee(out Employee employee);

            if (employee.Id == employeeId)
            {
                return BadRequest("Нельзя удалить самого себя");
            }

            _employeeService?.RemoveEmployee(employeeId);

            var listEmployee = _employeeService.GetEmployees();


            return RedirectToAction("Index","Home");
        }
    }
}
