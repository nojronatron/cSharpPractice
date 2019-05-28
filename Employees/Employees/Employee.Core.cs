using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    partial class Employee
    {  // All Partial Class files MUST include keyword partial in their class definition and be in the same Namespace
        // Field Data
        private string empName;
        private int empID;
        private float currPay;
        private int empAge;
        private string empSSN = ""; // note default value assignment

        // Constructors
        public Employee() { }
        public Employee(string name, int age, int id, float pay, string ssn) : this(name, age, id, pay) { empSSN = ssn; } // chained to ctor(name,age,id,pay)
        public Employee(string name, int id, float pay) : this(name, 0, id, pay) { } // Constructor Chaining -- a placeholder for int age is defaulted
        public Employee(string name, int age, int id, float pay)
        {
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
        }

        // Properties
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15) Console.WriteLine("Errror! Name length exceeds 15 characters!");
                else empName = value;
            }
        }
        public int ID
        {
            get { return empID; }
            set
            {
                if (value > 999)
                    Console.WriteLine("Error! Employee ID must be a valid number between 001 and 999!");
                else
                    empID = value;
            }
        }
        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }
        // Property as Expression-Bodied Member:
        public int Age
        {
            get => empAge;
            set => empAge = value;
        }  // Fewer characters, much cleaner, still readable, NOT useful if Logic is needed

        public string SocialSecurityNumber
        {
            get { return empSSN; }
        }
    }
}
