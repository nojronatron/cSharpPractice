using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritAndPoly_Try1
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(27, "Subaru");
            Car myOtherCar = new Car();
            Sports hisCar = new Sports();
            
            Console.WriteLine($"My Car Brandname: {myCar.BrandName}");
            Console.WriteLine($"My Car MPG: {myCar.MPG}");
            Console.WriteLine();

            Console.WriteLine($"My Other Car Brandname: {myOtherCar.BrandName}");
            Console.WriteLine($"My Other Car MPG: {myOtherCar.MPG}");
            Console.WriteLine();

            Console.WriteLine($"His Car Brandname: {hisCar.BrandName}");
            Console.WriteLine($"His Car MPG: {hisCar.MPG}");

            // Pause program execution before exiting
            Console.ReadLine();
        }
    }

    public class Car
    {
        // Properties
        private int mpg;

        public Car(int milesPerGallon, string brand)
        {
            // Custom Constructor
            this.mpg = milesPerGallon;
            this.BrandName = brand;
        }
        public Car()
        {
            // Default Constructor
            this.mpg = 35;
            this.BrandName = "";
        }

        // Accessors
        public int MPG { get { return mpg; } set { this.mpg = MPG; } }
        public string BrandName { get; }

    }

    public class Sports : Car
    {
        // This class is a sub-class of the parent class Car
        // Custom Constructor
        public Sports()
        {
            // To be completed
        }
    }
}
