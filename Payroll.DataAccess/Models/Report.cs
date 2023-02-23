using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DataAccess.Models
{
    public class Report
    {
        public Employee Employee { get; set; } 
        public List<Mission> Missions { get; set; }
        public int TotalHours { get; set; }
        public decimal TotalSalary { get; set; }
        public DateTime Date { get; set; }


    }
}
