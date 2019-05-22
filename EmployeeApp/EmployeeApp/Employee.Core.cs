using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    partial class Employee
    {  // All Partial Class files MUST include keyword partial in their class definition and be in the same Namespace
        // Field Data
        private string empName;
        private int empID;
        private float currPay;
        private int empAge;

        // Constructors
        public Employee() { }
        public Employee(string name, int id, float pay) : this(name, 0, id, pay) { } // Constructor Chaining
        public Employee(string name, int age, int id, float pay)
        {
            // Master Constructor
            // Business logic could exist here as well as in the Properties but that duplicates code and is more work
            // Instead USE PROPERTIES in the Constructor so the business logic in the Properties is executed every time!
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
        }

    }
}
