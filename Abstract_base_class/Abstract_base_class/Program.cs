using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_base_class
{
    class Program
    {
        static void Main(string[] args)
        {
            // fails: Employee juan = new Employee("Juan", "Riviera", "0001");
            // this is expected because the abstract method() has no body and the base class is abstracted so that
            // child classes can use it to define their instances
            SalariedEmployee juan = new SalariedEmployee("Juan", "Herrera", 0010, 80_000);
            HourlyEmployee tom = new HourlyEmployee("Tom", "Jones", 0101, 40, 20);
            ExecutiveEmployee lisa = new ExecutiveEmployee("Lisa", "McNamera", 0001, 200_000, 100_000, 200);

            Display(juan);
            Display(tom);
            Display(lisa);


            Console.WriteLine();
            Console.ReadLine();
        }
        static void Display(Employee emp)
        {
            // polymorphism allows this static method to recognize any child to the Employee parent class
            // casting will happen automatically/natively
            Console.WriteLine(emp.ToString());
        }
    }
}
