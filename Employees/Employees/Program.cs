using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void CastingExamples()
        {
            // a Manager "is-a" System.Object so we can store a Manager ref in an obj variable
            object frank = new Manager("Frank Zappa", 9, 3000, 40_000, "111-11-1111", 5);
            // a Manager "is-a" Employee...
            Employee moonUnit = new Manager("MoonUnit Zappa", 2, 3001, 20_000, "101-11-1321", 1);
            // a PTSalesPerson "is-a" SalesPerson...
            SalesPerson jill = new PTSalesPerson("Jill", 834, 3002, 100_000, "111-12-1119", 90, "Frank Zappa"); // I customized by adding mgrName
            // ...when two classes are releated by an "is-a" relationship it is always safe to store a derived object within a base class reference
            //   Doing so is called 'implicit casting', given the laws of Inheritance
            GivePromotion(moonUnit);
            GivePromotion(jill);
            GivePromotion((Manager)frank);  // frank is higher in the object hierarchy than Employee so an Explicit Cast is required
            //                                  An Explicit Cast looks like e.g.: (ClassIWantToCastTo)referenceIHave
        }
        static void GivePromotion(Employee emp)
        {
            // Increase pay... give new parking space in company garage...
            Console.WriteLine($"{emp.Name} was promoted!");
        }
        static void Main(string[] args)
        {
            // create a subclass object and access base class functionality
            Console.WriteLine("***** This Employee class Hierarchy *****\n");
            SalesPerson fred = new SalesPerson
            {
                Age = 31,
                Name = "Fred",
                SalesNumber = 50
            };

            // Nested Type Definitions
            // Create and use the public inner class
            // example: Employee.BenefitPackage.BenefitPackageLevel.Platinum;

            Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
            double cost = chucky.GetBenefitCost(); // calling the BenefitPackage, a class instance within the employee class with its own property

            PTSalesPerson pauly = new PTSalesPerson("Paul", 22, 298, 28_000, "444-99-4990", 1, "Fred");
            // "Paul", 22, 298, 28_000, "444-99-4990", 1, "Fred" or "Chucky"

            // display how things are going
            Console.WriteLine($"\nSalesPerson *** {fred.GetName()} ***");
            fred.DisplayStats();

            Console.WriteLine($"\nManager *** {chucky.GetName()} ***");

            chucky.DisplayStats();

            Console.WriteLine($"\nPartTime SalesPerson *** {pauly.GetName()} ***");
            pauly.DisplayStats();
            Console.Write($"{pauly.GetName()} reports to:");
            Console.Write($"{pauly.ManagerName()}\n\n");

            // give a bonus
            float bonusAmt = 2_500;
            chucky.GiveBonus(bonusAmt);
            Console.WriteLine("{0} got a bonus of {1:c}!", chucky.Name, bonusAmt);
            chucky.DisplayStats();
            Console.WriteLine();

            SalesPerson fran = new SalesPerson("Fran", 43, 93, 3000, "932-32-3232", 31);
            fran.GiveBonus(200);
            fran.DisplayStats();
            Console.WriteLine();

            // give a promotion or two
            GivePromotion(fran);
            GivePromotion(pauly);


            // temporarily showing Casting Examples method()
            CastingExamples();


            // the need for an abstract class:
            // Employee emmy = new Employee("Emma", 34, 239, 47_000, "324-23-3434");
            // emmy.DisplayStats();
            // to avoid allowing instantiation of an employee with no assignment/job classification
            // MUST remove keyword abstract from the Employee Class

            // pause program executions before exit
            Console.ReadLine();
        }
    }
}
