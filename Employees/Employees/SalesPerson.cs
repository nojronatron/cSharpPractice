using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    // salespeople need to know their number of sales
    class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }

        // as a general rule all subclasses should explicitly call an appropriate base class constructor
        public SalesPerson(string fullName, int age, int empID, float currPay, string ssn, int numbOfSales) 
            : base(fullName, age, empID, currPay, ssn)
        {
            // This property belongs to SalesPerson class
            this.SalesNumber = numbOfSales;
        }
        public SalesPerson() { } // a default CTOR is needed when a Custom CTOR is added

        public override sealed void GiveBonus(float amount) // overrides virtual member in parent class Employee
        { // Methods() can be sealed also; this Method() is sealed so that PTSalesPerson.SalesPerson.Employee cannot get a bonus
            int salesBonus = 0;
            if (SalesNumber >= 0 && SalesNumber <= 100) salesBonus = 10;
            else
            {
                if (SalesNumber >= 101 && SalesNumber <= 200) salesBonus = 15;
                else salesBonus = 20;
            }
            base.GiveBonus(amount * salesBonus);
        }
        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine($"Number of Sales: {SalesNumber}");
        }
    }
}
