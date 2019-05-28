using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterTank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the amount of H2O in the first water tank: ");
            double amountTank1 = double.Parse(Console.ReadLine());
            WaterTank tank1 = new WaterTank(amountTank1);

            Console.Write("\nEnter the amount of H2O in the second water tank: ");
            double amountTank2 = double.Parse(Console.ReadLine());
            WaterTank tank2 = new WaterTank(amountTank2);

            WaterTank tank3 = WaterTank.Combine(tank1, tank2);
            Console.WriteLine();

            Display(tank1, "tank1");
            Display(tank2, "tank2");
            Display(tank3, "tank3");







            // Pause program execution before exiting
            Console.WriteLine();
            Console.ReadLine();
        }
        public static void Display(WaterTank tank, string tankName)
        {  //  If a message is needed to add to the writeline below, then add a parameter to the Display() Method
            Console.WriteLine($"{tankName} has {tank.Amount} gallons.");
        }
    }
}
