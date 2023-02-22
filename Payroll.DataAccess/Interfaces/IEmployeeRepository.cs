using Payroll.DataAccess.Models;

namespace Payroll.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByName(string name);
        Task DeleteEmployee(Employee employee);
        Task SaveEmployee(Employee employee);


    }
}
