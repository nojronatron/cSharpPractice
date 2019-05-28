using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    // salespeople need to know their number of sales
    class SalesPerson:Employee
    {
        public int SalesNumber { get; set; }

        // as a general rule all subclasses should explicitly call an appropriate base class constructor
        public SalesPerson(string fullName, int age, int empID, float currPay, string ssn, int numbOfSales) :base(fullName, age, empID, currPay, ssn)
        {
            // This property belongs to SalesPerson class
            SalesNumber = numbOfSales;
        }
        public SalesPerson() { } // a default CTOR is needed when a Custom CTOR is added

    }
}
