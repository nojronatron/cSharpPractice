using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overriding_Equals_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box(2, 3, 4, "box1");
            Display(box1, "Obj box1");
            Box box2 = box1;
            Display(box2, "Obj box2");

            //Console.WriteLine("\nIs box1.Equals(box2) ?");
            //// Use the Equal() method to check for equality
            //if (box1.Equals(box2)) { Console.WriteLine("Box1 *is* equal to Box2"); } // Object.Equals() is an Instance Method()
            //else { Console.WriteLine("Box1 is *NOT equal* to Box2"); }


            Box box3 = new Box(3, 4, 5, "box3");
            Display(box3, "Obj box3");
            Box box4 = new Box(3, 4, 5, "box4");
            Display(box4, "Obj box4");

            RunComparison(box1, box2);
            RunComparison(box3, box4);


            // Pause execution before exiting
            Console.WriteLine();
            Console.ReadLine();
        }
        static void Display(Box box, string msg)
        {
            Console.WriteLine($"{msg}: {box}"); // implicitly calls box.ToSTring()
        }
        static void RunComparison(Box b1, Box b2)
        {
            Console.WriteLine($"\nIs first box equal to second box: {b1.Name}.Equals({b2.Name}) ?");
            // Use the Equal() method to check for equality
            if (b1.Equals(b2)) { Console.WriteLine($"{b1.Name} *is* equal to {b2.Name}"); } // Object.Equals() is an Instance Method() and tests for REFs
            else { Console.WriteLine($"{b1.Name} is *NOT equal* to {b2.Name}"); }
        }
    }
}
