using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_with_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            double r = rand.Next(1, 10);
            double l = rand.Next(1, 10);
            double h = rand.Next(1, 10);
            double w = rand.Next(1, 10);

            Circle c1 = new Circle(r);
            Cylinder cy1 = new Cylinder(r, h);
            Rectangle_JR r1 = new Rectangle_JR(l, w);
            Box b1 = new Box(l, w, h);

            List<IShape> ishps = new List<IShape>();
            ishps.Add(c1);
            ishps.Add(cy1);
            ishps.Add(r1);
            ishps.Add(b1);

            for (int i = 0; i < ishps.Count(); i++)
            {
                Display(ishps[i]);
            }

            // FYI: IShape c2 = new Circle(5); works and will dis-allow access to Properties (which might be desireable)


            Console.Write("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        static void Display(IShape shape)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Object: {shape.GetType().Name}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{shape}\n\n"); // the term ToString() isn't required (default display behavior)
            Console.ResetColor();
        }
    }
}
