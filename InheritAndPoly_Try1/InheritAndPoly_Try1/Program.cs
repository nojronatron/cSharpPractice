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
            Sports sportsCar1 = new Sports();
            // Sports sportsCar2 = new Sports()
            
            Console.WriteLine($"My Car Brandname: {myCar.BrandName}");
            Console.WriteLine($"My Car MPG: {myCar.MPG}");
            Console.WriteLine();

            Console.WriteLine($"My Other Car Brandname: {myOtherCar.BrandName}");
            Console.WriteLine($"My Other Car MPG: {myOtherCar.MPG}");
            Console.WriteLine();

            Console.WriteLine($"This Sports Car Brandname: {sportsCar1.BrandName}");
            Console.WriteLine($"This Sports Car has {sportsCar1.NumberOfCylinders} cylinders.");
            Console.WriteLine($"This Sports Car MPG: {sportsCar1.MPG}");
            
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
            this.BrandName = "Ford";  // TESTING
        }

        // Accessors
        public int MPG { get { return mpg; } set { this.mpg = MPG; } }
        public string BrandName { get; set; }  // Added a set otherwise Child Class cannot store BrandName here

    }

    public class Sports : Car
    {
        public Sports()
        {
            BrandName = "default"; // this is a test. without an object reference a default is used instead
            NumberOfCylinders = 6;
        }
        // This class is a sub-class of the parent class Car
        // Custom Constructor
        public Sports(Car car, int cylinders)
        {
            // Call the Car Constructor -- will store BrandName data in the Car (Parent) Class
            BrandName = car.BrandName;
            NumberOfCylinders = cylinders;
            MPG = car.MPG;
        }
        public int NumberOfCylinders { get; set; }

    }
}
