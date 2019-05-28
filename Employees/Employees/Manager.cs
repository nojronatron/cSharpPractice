using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    // managers need to know their number of stock options
    class Manager : Employee
    {
        public int StockOptions { get; set; }
        public Manager(string fullName, int age, int empID, float currPay, string ssn, int numbOfOpts) : base(fullName, age, empID, currPay, ssn)
        {
            // this property is defined by the Manager class:
            StockOptions = numbOfOpts;

            // assign incoming parameters using the inherited properteis of the parent class
            ID = empID;
            Age = age;
            Name = fullName;
            Pay = currPay;
            // SocialSecurityNumber = ssn; // commented out because using CTOR chaining instead
        }
        public Manager() { } // default CTOR still needed when Custom CTOR added to the class

    }
}
