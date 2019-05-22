using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{ // Big Note: Automatic Properties never do more than provide simple encapsulation for private data
    // via the compiler.
    class Garage
    {
        // The hidden int backing field is set to zero!
        // public int NumberOfCars { get; set; }
        // The hidden int backing field will now be set to 1
        public int NumberOfCars { get; set; } = 1;

        // The hidden Car backing field is set to null! UNLESS Constructurs are created to safely instantiate
        // public Car MyAuto { get; set; }
        // The hidden Car backing field will now be set to a new Car object
        public Car MyAuto { get; set; }=new Car();

        // Must use Constructors to override default values assigned to hidden backing fields
        public Garage()
        {
            // With Automatic Properties and the improved default setting statements above
            // the following is no longer needed:
            // MyAuto = new Car();
            // NumberOfCars = 1;
            // Instead the hidden backing Fields (set up above) do the work so this Constructor can be empty
        }
        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }
    }
    class Car
    {
        // Automatic properties - no need to define backing fields
        public string PetName { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }
        public bool NeedsRepair { get; set; }
        public int Year { get; }  // Read only

        public void DisplayStats()
        {
            Console.WriteLine($"Car Name: {PetName}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Color: {Color}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Automatic Properties *****\n");

            // make a Car instance
            Car c = new Car
            {  // per IDE suggestion: Instantiate object in one code set instead of line-by-line
                PetName = "Frank",
                Speed = 55,
                Color = "Red"
            };

            Console.WriteLine($"Your car is named {c.PetName}? That's odd...");
            c.DisplayStats();
            Console.WriteLine("\n\n");

            // put Car instance in the garage
            Garage g = new Garage
            {
                MyAuto = c
            };

            // Prints default value of zero:
            Console.WriteLine($"Number of Cars in garage: {g.NumberOfCars}");

            // Runtime error when backing field is currently null (fixed by adding a Constructor to Garage class
            Console.WriteLine($"Your car is named: {g.MyAuto.PetName}");

            Console.ReadLine();
        }
    }
}
