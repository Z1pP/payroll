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
            HttpContext.Session.TryGetEmployee(out Employee? employee);

            var removedEmployee = _employeeService.GetEmployeeById(employeeId);

            //Если удаляемый сотрудник это сорудник из сессии
            if (employee.Id == removedEmployee.Id)
            {
                return BadRequest("Нельзя удалить самого себя");
            }
            
            _employeeService?.RemoveEmployee(removedEmployee);

            return RedirectToAction("Index","Home");
        }

        public IActionResult GetMissionByDate(DateTime startDate, int employeeId)
        {
            var report = _reportService.GetReportForEmployeeByDate(startDate, employeeId);
            return View("Index", report);
        }
    }
}
