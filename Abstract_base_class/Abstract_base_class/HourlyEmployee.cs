using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_base_class
{
    public class HourlyEmployee: Employee
    {
        private decimal _hourlyWage;
        private decimal _hoursWorked;
        public HourlyEmployee(string firstname, string lastname, int employeeID, decimal hoursWorked, decimal hourlyWage) : base(firstname, lastname, employeeID)
        {
            _hoursWorked = hoursWorked;
            _hourlyWage = hourlyWage;
        }
        public override string ToString()
        {
            return base.ToString() + $"{GetWeeklySalary(),-10}";
        }
        public override decimal GetWeeklySalary()
        {
            return _hourlyWage * _hoursWorked;
        }
    }
}
