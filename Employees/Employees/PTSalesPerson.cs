using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    sealed class PTSalesPerson: SalesPerson
    {
        // this sealed Class cannot be extended, however it extends SalesPerson and utilized CTOR Chaining to aid in instance initialization
        private string ReportsTo;
        public PTSalesPerson(string fullName, int age, int empID, float currPay, string ssn, int numbOfSales, string mgrName) 
            :base(fullName, age, empID, currPay, ssn, numbOfSales)
        {
            ReportsTo = mgrName; // DONT put a Type in front of the variable here else it is defining a newly scoped object
        }
        public PTSalesPerson() { } // Default Constructor

        // other members would be here

        public string ManagerName()
        {
            return ReportsTo;
        }
    }
}
