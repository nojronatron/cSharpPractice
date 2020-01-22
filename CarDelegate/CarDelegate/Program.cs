using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    class Program
    {
        //  1. define a new delegate type that will be used to send notifications to the caller
        //  2. declare a member variable of this delegate in teh Car class
        //  3. create a helper function on the Car that allows the caller to specify the method to call back on
        //  4. implement the Accelerate() method to invoke the delegate's invocation list under the correct circumstances

        static void Main(string[] args)
        {
            Console.WriteLine("***** Delegates as Event Enablers *****");

            //  first make a Car object
            Car freddy = new Car("Freddy", 100, 20);

            //  next tell the car which method to call when it wants to send us messages
            freddy.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            //  speed up to trigger the events
            Console.WriteLine("***** Speeding up... *****");
            for (int i = 1; i<11; i++)
            {
                freddy.Accelerate(10);
            }


            Console.WriteLine("Press <Enter> to exit. . .");
            Console.ReadLine();
        }
        //  this is the target for incoming events
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine($"=> { msg }");
            Console.WriteLine("***********************************\n");
        }
    }
}
