using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Encapsulation *****\n");
            Employee emp = new Employee("Marvin", 456, 50_000);
            emp.GiveBonus(1000);
            emp.DisplayStats();

            // Reset and then get the Name property
            emp.Name = "Marv";
            Console.WriteLine($"Employee is named: {emp.Name}");


            // Pause program execution before exit
            Console.ReadLine();
        }
    }
}
