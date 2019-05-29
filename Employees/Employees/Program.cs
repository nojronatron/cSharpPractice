using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
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
            Console.Write(pauly.ManagerName());
            

            // pause program executions before exit
            Console.ReadLine();
        }
    }
}
