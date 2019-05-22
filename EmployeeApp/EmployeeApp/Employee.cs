using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Employee
    {
        // Field data
        private string empName;
        private int empID;
        private float currPay;
        private int empAge;

        // Properties:
        // Accessor (get method) and Mutator (set method) are complex when business logic needs to be computed
        // Properties are composed by defining a get scope (accessor) and set scope (mutator) directly
        // value is a contextual keyword, representin the value eing assigned by the caller and...
        // ...have the same type as the Property itself.
        // The ONLY appropriate place to directly reference underlying private data is within the Property itself.
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                else
                    empName = value;
            }
        }
        public int ID { get { return empID; } set { if (value > 999)
                    Console.WriteLine("Error! Employee ID must be a valid number between 001 and 999!");
                else
                    empID = value; } }
        public float Pay { get { return currPay; } set { currPay = value; } }
        // Property as Expression-Bodied Member:
        public int Age { get => empAge; set => empAge = value; }  // Fewer characters, much cleaner, still readable

        // Constructors
        public Employee() { }
        public Employee(string name, int id, float pay) : this(name, 0, id, pay) { } // Constructor Chaining
        public Employee(string name, int age, int id, float pay)
        {
            // Master Constructor
            // Business logic could exist here as well as in the Properties but that duplicates code and adds work
            // Instead USE PROPERTIES in the Constructor so the business login in the Properties is executed every time!
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
        }

        // Methods
        public void GiveBonus(float amount)
        {
            Pay += amount;  // reference the PROPERTY here also
        }

        public void DisplayStats()
        {
            // No: Console.WriteLine($"Name: {empName}"); Reference the PROPERTY instead
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Pay: {Pay}");
        }


    }
}
