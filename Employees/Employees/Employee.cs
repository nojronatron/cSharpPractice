using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    partial class Employee
    {  //  All partial class files MUST have keyword partial in their class definition and be in the same Namespace
       // Field data

        // Properties:
        // Accessor (get method) and Mutator (set method) are complex when business logic needs to be computed
        // Properties are composed by defining a get scope (accessor) and set scope (mutator) directly
        // value is a contextual keyword, representin the value eing assigned by the caller and...
        // ...have the same type as the Property itself.
        // The ONLY appropriate place to directly reference underlying private data is within the Property itself.

        // Constructors

        // Methods
        public void GiveBonus(float amount)
        {
            Pay += amount;  // reference the PROPERTY here also
        }
        public string GetName()
        {
            return empName;
        }
        public void SetName(string name)
        {
            // MUTATOR
            // Check incoming value before making assignment
            if (name.Length > 15) { Console.WriteLine("Error! Name must be less than 15 characters!"); }
            else empName = name;
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