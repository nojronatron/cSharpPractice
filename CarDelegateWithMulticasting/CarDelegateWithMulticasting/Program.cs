using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegateWithMulticasting
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

            //  register a secont target for the notification
            //      ...but hold onto it so unsubscribe can be done later
            Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEvent2);

            //  time has passed so register now
            freddy.RegisterWithCarEngine(handler2);

            //  speed up to trigger the events
            Console.WriteLine("***** Speeding up... *****");
            for (int i = 0; i < 9; i++)
            {
                freddy.Accelerate(15);
            }

            //  unregister from the second handler
            freddy.UnRegisterWithCarEngine(handler2);

            //  slow the car down
            freddy.CurrentSpeed = 30;
            if (freddy.FixMyCar())
            {
                Console.WriteLine($"{ freddy.PetName } is fixed! Current speed is: { freddy.CurrentSpeed }.\n");
            }

            //  no more UPPERCASE messages after unregistering
            Console.WriteLine("***** Speeding up... *****");
            for (int i = 0; i < 9; i++)
            {
                freddy.Accelerate(15);
            }

            Console.WriteLine("Press <Enter> to exit. . .");
            Console.ReadLine();
        }
        //  this is the target for incoming events
        //  there are now TWO methods that will be called by the Car when sending notifications
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine($"=> { msg }");
            Console.WriteLine("***********************************\n");
        }
        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine($"=> { msg.ToUpper() }");
        }
    }
}
