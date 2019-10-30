using System;
using System.Collections;

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
                Console.WriteLine($"Class defining member: {ex.TargetSite.DeclaringType}");
                Console.WriteLine($"Member type: {ex.TargetSite.MemberType}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"Stack: {ex.StackTrace}");

                Console.WriteLine("\n=> Custom Data");
                foreach (DictionaryEntry de in ex.Data)
                {
                    Console.WriteLine($"=> {de.Key}, {de.Value}");
                }
            }   //  The error has been handled, processing continues with the next statements...
            Console.WriteLine("\n***** Out of exception logic *****");
            Console.ReadLine();
        }
    }
}
