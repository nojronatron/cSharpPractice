using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_Overloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box(1, 2, 3);
            Box box2 = new Box(2, 3, 4);
            // instance method addition
            Box box3 = box1.Add(box2);
            Console.WriteLine("Adding two boxes using the Instance Add method()");
            Display(box1, "box1");
            Display(box2, "box2");
            Display(box3, "box3");

            // static method addition
            Console.WriteLine("\n\nAdding two boxes using the Static Add method()");
            Box box4 = new Box(4, 5, 6);
            Box box5 = new Box(5, 6, 7);
            Box box6 = Box.SAdd(box4, box5);
            Display(box4, "box4");
            Display(box5, "box5");
            Display(box6, "box6");

            // operator overload addition
            Console.WriteLine("\n\nAdding two boxes using Operator Overload");
            Box box7 = new Box(6, 7, 8);
            Box box8 = new Box(7, 8, 9);
            Box box9 = box8 - box7;
            Display(box7, "box7");
            Display(box8, "box8");
            Display(box9, "box9");

            // freebee overloaded operator +=
            Box box10 = new Box(1, 2, 3);
            Display(box10, "box10");
            box10 += box10;
            Display(box10, "box10");
            box10 += box10;
            Display(box10, "box10");
            box10 += box10;
            Display(box10, "box10");
            box10 += box10;
            Display(box10, "box10");

            // operator overload gt and lt
            Console.WriteLine("\n\nComparing boxes less-than and greater-than, by volume");
            Console.WriteLine($"box1 has more volume than box2: {box1 > box2}");
            Console.WriteLine($"box2 has more volume than box1: {box2 > box1}");
            Console.WriteLine($"box8 has less volume than box3: {box8 < box3}");
            Console.WriteLine($"box3 has less volume than box8: {box3 < box8}");

            // pause program before exiting
            Console.ReadLine();
        }
        // method() to display a box
        static void Display(Box box, string msg)
        {
            Console.WriteLine($"{msg}\tL: {box.Length}\tW: {box.Width}\tH: {box.Height}\tV: {box.GetVolume()}");
        }
    }
}
