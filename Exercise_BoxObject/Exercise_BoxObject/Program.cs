using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_BoxObject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two box instances
            Box defaultBox = new Box();
            Box customBox = new Box(2, 3, 4);

            // Calling the Display Methods, once for each Object instance
            Display(defaultBox);
            Console.WriteLine();
            Display(customBox);

            // Pause execution before program exits
            Console.WriteLine();
            Console.ReadLine();
        }

        static void Display(Box b)
        {
            // Method to display the box Length, Width, Height, and Volume
            Console.WriteLine($"Box {b} Length: {b.Length}; Width: {b.Width}; Height: {b.Height}.");
            Console.WriteLine($"Box Volume is {b.GetVolume()}");
        }
    }
}
