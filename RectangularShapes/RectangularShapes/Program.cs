using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangularShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 45);
            Console.Title = "***** Fun with Rectangles *****";

            // create one of each object
            MyRectangle mr1 = new MyRectangle();
            MyRectangle mr2 = new MyRectangle(2, 3);
            Box b1 = new Box(2, 3, 4);
            Pyramid p1 = new Pyramid(2, 3, 4);

            // display each object using overridden ToString() Method
            Console.WriteLine($"{mr1.ToString()}"); // test Default CTOR (empty)
            Console.WriteLine($"{mr2.ToString()}");
            Console.WriteLine($"{b1.ToString()}"); // chained CTOR
            Console.WriteLine($"{p1.ToString()}");

            // pause program execution before exiting
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
