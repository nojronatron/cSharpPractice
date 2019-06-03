using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpOverloading_Cylinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Operator Overload: Cylinders *****");

            Cylinder c1 = new Cylinder(1, 2);
            Cylinder c2 = new Cylinder(3, 4);
            Cylinder c3 = c1 + c2;
            Cylinder c4 = c2 - c1;
            Cylinder c5 = new Cylinder(1, 2);

            Display(c1, "c1");
            Display(c2, "c2");
            Display(c3, "c3");
            Display(c4, "c4");
            Display(c5, "c5");

            Console.WriteLine($"c1 is gt c2: {c1 > c2}");
            Console.WriteLine($"c2 is gt c1: {c1 < c2}");
            Console.WriteLine($"c1 is equal to c2: {c1 == c2}");
            Console.WriteLine($"c1 is not equal to c2: {c1 != c2}");
            Console.WriteLine($"c1 is equal to c5: {c1 == c5}");


            // pause program before exitinig
            Console.ReadLine();
        }
        static void Display(Cylinder c, string cylinderName)
        {
            Console.WriteLine($"Cylinder {cylinderName}:\tR: {c.Radius}\tH: {c.Height}\tV: {c.Volume}\tA: {c.SurfaceArea}");
        }
    }
}
