using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****");
            Car myCar = new Car("Ted", 100, 10);

            //  register event handlers (method) with the instance's public event by using +=
            myCar.AboutToBlow += new Car.CarEngineHandler(CarIsAlmostDoomed);
            myCar.AboutToBlow += new Car.CarEngineHandler(CarAboutToBlow);

            //  attach/register with an event with +=
            Car.CarEngineHandler dead = new Car.CarEngineHandler(CarExploded);  //  the delegate 'CarEngineHandler'
            myCar.Exploded += dead; //  registering CarEngineHandler 'dead' with the event

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i <= 6; i++)
            {
                myCar.Accelerate(20);
            }

            //  detach from a source of events with -=
            myCar.Exploded -= dead;

            Console.WriteLine("\n***** Speeding up *****");
            for (int i=0; i<6; i++)
            {
                myCar.Accelerate(20);
            }

            //  add it back and see what happens
            myCar.Exploded += dead;

            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i <= 6; i++)
            {
                myCar.Accelerate(20);
            }


            Console.WriteLine("\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        //  create static methods for the caller
        public static void CarAboutToBlow(object sender, CarEventArgs e)
        //public static void CarAboutToBlow(string msg)
        {
            //  updated to support Custom Event Arguments
            if (sender is Car c)
            {
                Console.WriteLine($"Critical Message from { c.PetName }: { e.msg }.");
            }
            //Console.WriteLine(msg);
        }
        public static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        //public static void CarIsAlmostDoomed(string msg)
        {
            if (sender is Car c)
            {
                Console.WriteLine($"Warning Message from { c.PetName }: { e.msg }.");
            }
            //Console.WriteLine(msg);
        }
        public static void CarExploded(object sender, CarEventArgs e)
        //public static void CarExploded(string msg)
        {
            if (sender is Car c)
            {
                Console.WriteLine($"Error Message from { c.PetName }: { e.msg }.");
            }
            //Console.WriteLine(msg);
        }
    }
}
