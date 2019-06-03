using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Polymorphism *****\n");
            // make an array of Shape-compatible objects
            Shape[] myShapes = { new Hexagon(), new Circle(), new Hexagon("Mick"), new Circle("Beth"), new Hexagon("Linda") };
            // Loop over each item (above) and interact with the polymorphic interface
            foreach (Shape s in myShapes)
            {
                s.Draw();
            }
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine();

            Hexagon hex = new Hexagon("Beth");
            hex.Draw(); // calls Hexagon.Draw() method()
            Circle cir = new Circle("Cindy");
            cir.Draw(); // calls base class implementation

            // Pause program execution before exit
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
