using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents_AnonymousMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Anonymous Methods *****\n");
            Car c1 = new Car("SlugBug", 100, 10);

            //  register event handlers as anonymous methods
            c1.AboutToBlow += delegate
            {
                Console.WriteLine("Eek! Going too fast!");
            };

            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine($"Message from Car: { e.msg }.");
            };

            c1.Exploded += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine($"Fatal message from Car: { e.msg }.");
            };

            //  this will eventually trigger the events
            for (int i=0; i<7; i++)
            {
                c1.Accelerate(20);
            }



            Console.Write("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
    }
}
