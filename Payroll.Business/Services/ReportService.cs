
using Payroll.DataAccess.Models;

namespace Payroll.Business.Services
{    
    public class ReportService
    {
        private static EmployeeService? _employeeService;

        public ReportService(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //Получаем отчет по зарплате сотрудника через его ID
        public  Report GetReportForEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            var employeeMissions = _employeeService.GetEmployeeMissions(id);

            return CreateReport(employee, employeeMissions);
        }

        //Получение отчета по зп через дату
        public Report GetReportForEmployeeByDate(DateTime date, int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            var employeeMissions = _employeeService.GetEmployeeMissions(id)
                .Where(x => x.Date == date).ToList();

            return CreateReport(employee, employeeMissions);
        }

        private Report CreateReport(Employee employee, List<Mission> missions)
        {
            var totalTime = missions.Sum(x => x.WorkingTime);

            var report = new Report
            {
                Employee = employee,
                Missions = missions,
                Date = DateTime.Now,
                TotalHours = totalTime,
                TotalSalary = GetTotalSalary(employee, totalTime)
            };

            return report;
        }

        //Проводим рассчеты Зп исходя из задания для каждого отдельного сотрудника
        private static decimal GetTotalSalary(Employee employee, int totalHours)
        {
            employee.TotalWorkingHoursPerMonth = totalHours;

            decimal totalSalary;

            switch (employee.Role)
            {
                case "Manager":
                {
                    totalSalary = (decimal)employee.TotalWorkingHoursPerMonth / 160 * 200000m;

                    if (totalHours > 160)
                        totalSalary += 20000; // премия
                    break;
                }
                case "Worker":
                    totalSalary = (decimal)employee.TotalWorkingHoursPerMonth / 160 * 120000m;
                    break;
                default:
                    totalSalary = 1000 * (decimal)employee.TotalWorkingHoursPerMonth;
                    break;
            }

            _employeeService.UpdateEmployee(employee);

            return totalSalary;
        }
    }
}
