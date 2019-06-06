using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_base_class
{
    public class SalariedEmployee:Employee
    {
        private decimal _yearlySalary;
        public SalariedEmployee(string firstname, string lastname, int employeeID, decimal yearlySalary) : base(firstname, lastname, employeeID)
        {
            _yearlySalary = yearlySalary;
        }
        public override string ToString()
        {
            return base.ToString() + $"{_yearlySalary,-10}";
        }
        public override decimal GetWeeklySalary()
        {
            return _yearlySalary/52;
        }
    }
}
