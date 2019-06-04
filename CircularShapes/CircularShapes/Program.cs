using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(140, 12);
            Console.WriteLine("*** Fun with Circular Shapes ***");
            Console.WriteLine();

            Circle c1 = new Circle(2);
            Console.WriteLine(c1);

            Sphere s1 = new Sphere(2);
            Console.WriteLine(s1);

            Cylinder cy1 = new Cylinder(2, 2);
            Console.WriteLine(cy1);

            Cone co1 = new Cone(2, 2);
            Console.WriteLine(co1);

            // Pause program execution before exiting
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
