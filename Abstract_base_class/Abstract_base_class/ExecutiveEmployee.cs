using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_base_class
{
    class ExecutiveEmployee : SalariedEmployee
    {
        private decimal _bonus;
        private decimal _stockOptions;
        public ExecutiveEmployee(string firstname, string lastname, int employeeID, decimal yearlySalary, decimal bonus, decimal stockOptions) : 
            base(firstname, lastname, employeeID, yearlySalary)
        {
            _bonus = bonus;
            _stockOptions = stockOptions;
        }
        public override string ToString()
        {
            return base.ToString() + $"{_bonus, -10} {_stockOptions, -10}";
        }
        public override decimal GetWeeklySalary()
        {
            // TODO: Fix this
            return (yearlySalary / 52) + _bonus + (_stockOptions);
        }
    }
}
