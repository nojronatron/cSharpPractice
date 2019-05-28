using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInheritance
{
    class Car
    {
        public readonly int maxSpeed;
        private int currSpeed; // Private Field, can only be accessed within this Class... use Properties get & set for access)
        public Car(int max) { maxSpeed = max; }
        public Car() { maxSpeed = 55; }
        public int Speed { // Property. Is an Encapsulation service
            get { return currSpeed; }
            set {
                currSpeed = value;
                if (currSpeed == 88)
                    Console.WriteLine("You're travelling Back To The Future!");
                if (currSpeed > maxSpeed)
                {
                    currSpeed = maxSpeed;
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car(88);
            Console.WriteLine($"Speed: {c.Speed}");
            Console.WriteLine($"Max Speed: {c.maxSpeed}");
            Console.WriteLine("\nEnter a new speed: ");
            int newSpeed = int.Parse(Console.ReadLine());
            c.Speed = newSpeed;
            Console.WriteLine($"Speed changed to {newSpeed}? {c.Speed == newSpeed}");
            Console.WriteLine($"Speed: {c.Speed}");

            // Minivan stuff
            MiniVan mv = new MiniVan(); // parent constructor is NOT inherited
            mv.Speed = 10;
            Console.WriteLine($"\nMV Speed: {mv.Speed}; MV MaxSpeed: {mv.maxSpeed}.");

            Console.ReadLine();
        }
    }
}
