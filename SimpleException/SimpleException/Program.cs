using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    class Program
    {
        static void Main(string[] args)
        {
            //  get the car to overheat
            Console.WriteLine("***** Simple Exception Example *****");
            Console.WriteLine("=> Creating a car and flooring the accellerator!");

            Car myCar = new Car("Zippy", 20);
            myCar.CrankTunes(true);

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    myCar.Accelerate(10);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("\n*** Error! ***");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Source: {ex.Source}");
            }   //  The error has been handled, processing continues with the next statements...
            Console.WriteLine("\n***** Out of exception logic *****");
            Console.ReadLine();
        }
    }
}
