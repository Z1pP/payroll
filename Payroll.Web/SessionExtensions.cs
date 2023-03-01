using System.Data;
using System.Text;
using Payroll.DataAccess.Models.Employees;

namespace Payroll.Web
{
    public static class SessionExtensions
    {
        private const string key = "employee";

        public static void Set(this ISession session, Employee employee)
        {
            if (employee == null)
                return;

            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(employee.Id);
                writer.Write(employee.Name);
                writer.Write(employee.Role);
                writer.Write(employee.TotalHoursWorked);

                session.Set(key, stream.ToArray());
            }
        }
        public static bool TryGetEmployee(this ISession session, out Employee? employee)
        {
            if (session.TryGetValue(key, out byte[] buffer))
            {
                using (var stream = new MemoryStream(buffer))
                using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    var employeeId = reader.ReadInt32();
                    var employeeName = reader.ReadString();
                    var employeeRole = reader.ReadString();
                    var employeeTotalWorkingHours = reader.ReadInt32();

                    employee = employeeRole switch
                    {
                        "Manager" => new Manager(employeeName, employeeRole)
                        {
                            Id = employeeId, TotalHoursWorked = employeeTotalWorkingHours
                        },
                        "Worker" => new Worker(employeeName, employeeRole)
                        {
                            Id = employeeId,
                            TotalHoursWorked = employeeTotalWorkingHours
                        },
                        "Freelancer" => new Freelancer(employeeName, employeeRole)
                        {
                            Id = employeeId,
                            TotalHoursWorked = employeeTotalWorkingHours
                        },
                        _ => throw new ArgumentException("Данная должность отсутсвует", employeeName)
                    };

                    return true;
                }
            }

            employee = null;
            return false;
        }
    }
}
