using Microsoft.AspNetCore.Mvc;
using Payroll.Business.Services;

namespace Payroll.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ReportService _reportService;
        public EmployeeController(ReportService reportService)
        {
            _reportService = reportService;
        }


        [HttpPost]
        public IActionResult Details(int employeeId)
        {
            var report = _reportService.GetReportForEmployeeById(employeeId);
            
            return View(report);
        }
    }
}
