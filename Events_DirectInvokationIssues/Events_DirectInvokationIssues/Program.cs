using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_DirectInvokationIssues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Agh! No Encapsulation! *****\n");
            //  make a car
            car myCar = new car();
            //  we have direct access to the delegate!
            myCar.listOfHandlers = new car.CarEngineHandler(CallWhenExploded);
            myCar.Accelerate(10);

            //  we can now assign to a whole new object (confusing at best)
            myCar.listOfHandlers = new car.CarEngineHandler(CallHereToo);
            myCar.Accelerate(10);

            //  the caller can also directly invoke the delegate!
            myCar.listOfHandlers.Invoke("hee, hee, hee...");


            Console.WriteLine();
            Console.ReadLine();
        }
        static void CallWhenExploded(string msg)
        {
            Console.WriteLine(msg);
        }
        static void CallHereToo(string msg)
        {
            Console.WriteLine(msg);
        }
    }
    public class car
    {
        //  exposing public delegate members breaks encapsulation making difficult to maintain code and opens possible security risks
        //  to avoid these issues, declare private delegate member variables
        public delegate void CarEngineHandler(string msgForCaller);

        //  now a public member!
        public CarEngineHandler listOfHandlers;

        //  just fire out the Exploded notification
        public void Accelerate(int delta)
        {
            if (listOfHandlers != null)
            {
                listOfHandlers("Sorry, this car is dead...");
            }
        }
    }
}
