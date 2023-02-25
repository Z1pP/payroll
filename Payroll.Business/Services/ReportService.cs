using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.Business.Services
{    
    public class ReportService
    {
        private static  IEmployeeRepository? _employeeRepository;
        private static IMissionRepository? _missionRepository;

        public ReportService(IEmployeeRepository employeeRepository, IMissionRepository missionRepository)
        {
            _employeeRepository = employeeRepository;
            _missionRepository = missionRepository;
        }

        public  Report GetReportForEmployeeById(int id)
        {
            var employee = _employeeRepository?.GetEmployeeById(id);

            var missions = _missionRepository?.GetMissions();

            employee.Missions = missions.Where(x => x.EmployeeId == employee.Id).ToList();

            var totalTime = employee.Missions.Sum(x => x.WorkingTime);

            var report = new Report
            {
                Employee = employee,
                Missions = employee.Missions,
                Date = DateTime.Now,
                TotalHours = totalTime,
                TotalSalary = GetTotalSalary(employee, totalTime)
            };

            return report;
        }

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

            _employeeRepository?.UpdateEmployee(employee);

            return totalSalary;
        }
    }
}
