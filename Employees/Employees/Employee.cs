using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    abstract partial class Employee
    {  //  All partial class files MUST have keyword partial in their class definition and be in the same Namespace
       // Keyword abstract: programmatically protects against casting or initializing from this base Class
       //     ...there isn't much that Employee type means without digging into one of its child classes anyway
       // Fields
       //     Fields are now stored in partial class Employee.core.cs

        // Properties:
        //     Props are now stored in partial class Employee.core.cs
        
        // Accessor (get method) and Mutator (set method) are complex when business logic needs to be computed
        // Properties are composed by defining a get scope (accessor) and set scope (mutator) directly
        // value is a contextual keyword, representin the value eing assigned by the caller and...
        // ...have the same type as the Property itself.
        // The ONLY appropriate place to directly reference underlying private data is within the Property itself.

        // Constructors
        //     CTORS are now stored in partial class Employee.Core.cs
        
        // Methods
        public virtual void GiveBonus(float amount) // virtual allows a sub class to override the method
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
        public virtual void DisplayStats() // override enabled so sub classes can customize
        {
            // No: Console.WriteLine($"Name: {empName}"); Reference the PROPERTY instead
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Pay: {Pay:c0}");
            Console.WriteLine($"SSN: {SocialSecurityNumber}");
        }
        // Contain a BenefitsPackage object
        protected BenefitPackage empBenefits = new BenefitPackage(); //  has-a => containment/delegation model, or aggregation
        // Also see Nested.Type.Definitions; classes within classes => walk class namespaces to access within nested class scopes

        // expose certain benefit behaviors of an object
        public double GetBenefitCost() // a Method()...
        {
            return empBenefits.ComputePayDeduction();
        }
        // expose object through a custom property
        public BenefitPackage Benefits // an Accessor/Mutator
        {
            get { return empBenefits; }
            set { empBenefits = value; }
        }

    }
}