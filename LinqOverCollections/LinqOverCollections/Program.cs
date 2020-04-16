using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ over Generic Collections *****\n");

            List<Car> cars = new List<Car>()
            {
                new Car{ PetName="Scooby", Color="Light Blue", Make="Subaru", Speed=50 },
                new Car{ Speed=40, Make="Toyota", Color="Blue", PetName="Yoda" },
                new Car{ PetName="Ralph", Color="Brown", Make="Honda", Speed=30 },
                new Car{ Speed=20, Make="Ford", Color="Red", PetName="Roger" },
                new Car{ PetName="Henry", Color="Silver", Speed=100, Make="BMW" },
                new Car{ PetName="Daisy", Color="Tan", Speed=90, Make="BMW" },
                new Car{ PetName="Melvin", Color="White", Speed=43, Make="Ford" },
                new Car{ PetName="Clunker", Color = "Rust", Speed=5, Make="VW" }
            };
            Console.WriteLine("\nCars going faster than 55:");
            GetFastCars(cars);
            
            Console.WriteLine("\nBMW's going faster than 90:");
            GetFastBMWs(cars);


            Console.WriteLine("\n\n*** Non-generic Collection Example ***\n");
            //  non-generic collection of cars
            ArrayList myCars = new ArrayList()
            {
                new Car{ PetName="Scooby", Color="Light Blue", Make="Subaru", Speed=50 },
                new Car{ Speed=40, Make="Toyota", Color="Blue", PetName="Yoda" },
                new Car{ PetName="Ralph", Color="Brown", Make="Honda", Speed=30 },
                new Car{ Speed=20, Make="Ford", Color="Red", PetName="Roger" },
                new Car{ PetName="Henry", Color="Silver", Speed=100, Make="BMW" },
                new Car{ PetName="Daisy", Color="Tan", Speed=90, Make="BMW" },
                new Car{ PetName="Melvin", Color="White", Speed=43, Make="Ford" },
                new Car{ PetName="Clunker", Color = "Rust", Speed=5, Make="VW" }
            };
            //  transform ArrayList into an IEnumerable<T>-compatible type
            var myCarsEnum = myCars.OfType<Car>();

            //  Create a query expression targeting the compatible type
            var fastCars = from c in myCarsEnum
                           where c.Speed > 55
                           select c;

            foreach(var car in fastCars)
            {
                Console.WriteLine($"{ car.PetName } is going too fast!");
            }

            Console.WriteLine("\n\n*** OfType() As A Filter ***\n");
            OfTypeAsFilter();



            Console.ReadLine();
        }
        public static void OfTypeAsFilter()
        {
            //  extract the ints from the ArrayList
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });
            var myInts = myStuff.OfType<int>();

            //  print out results
            foreach (int i in myInts)
            {
                Console.WriteLine($"Int value: { i }");
            }
        }
        public static void GetFastBMWs(List<Car> myCars)
        {
            var fastBMWs = from fastBmw in myCars
                           where fastBmw.Speed > 90 && fastBmw.Make == "BMW"
                           orderby fastBmw.PetName
                           select fastBmw;

            foreach(var bmw in fastBMWs)
            {
                Console.WriteLine($"{ bmw.PetName } is going too fast!");
            }
        }
        public static void GetFastCars(List<Car> myCars)
        {
            //  find all Car objects in the List<> wher ethe speed is greater than 55
            var fastCars = from fastCar in myCars
                           where fastCar.Speed > 55
                           orderby fastCar.PetName
                           select fastCar;

            foreach (var car in fastCars)
            {
                Console.WriteLine($"{ car.PetName } is going too fast!");
            }
        }
    }
}

