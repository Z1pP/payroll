using Payroll.DataAccess.Models.Employees;

namespace Payroll.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByName(string name);
        void RemoveEmplyee(Employee employee);
        void RemoveEmployeeById(int id);
        void SaveEmployee(Employee employee);
        void UpdateEmployee(Employee employee);


    }
}
