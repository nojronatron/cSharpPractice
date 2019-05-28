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

            Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);


            // display how things are going
            Console.WriteLine($"SalesPerson Info: {fred.GetName()}:");
            fred.DisplayStats();

            Console.WriteLine($"/nManager Info: {chucky.GetName()}:");
            chucky.DisplayStats();

            // pause program executions before exit
            Console.ReadLine();
        }
    }
}
