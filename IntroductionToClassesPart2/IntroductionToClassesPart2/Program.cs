using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToClassesPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an object/instance of the car using default Constructor
            Car defaultCar = new Car();
            
            // Create an object/instance of the car using the custom Constructor
            Car myCar = new Car("Honda", "Civic", 2016, 42_000, 23_000);

            Display(myCar);
            Display(defaultCar);

            // pause program execution before exiting
            Console.ReadLine();
        }

        static void Display(Car car)
        {
            Console.WriteLine("\n*****");
            // Display the details of the Car object using Accessors a.k.a. getter/setters
            // Properties are back-door Read Access to Fields
            //
            // using the Java-based GETter: string make = car.GetMake();
            //
            // Now using Csharp properties
            string make = car.Make; // Properties are considered variables (not Methods() like in Java)
            Console.WriteLine($"Make: {make}");
            Console.WriteLine($"Model: {car.Model}");
            Console.WriteLine($"Year: {car.Year}");
            Console.WriteLine($"Mileage: {car.Mileage}");
            Console.WriteLine($"Price: {car.Price}");
            Console.WriteLine("*****\n");

        }
    }
}
