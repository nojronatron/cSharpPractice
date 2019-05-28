using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToObjects3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Length of your box: ");
            double l = double.Parse(Console.ReadLine());
            Console.Write("\nEnter the Width of your box: ");
            double w = double.Parse(Console.ReadLine());
            Console.Write("\nEnter the Height of your box: ");
            double h = double.Parse(Console.ReadLine());

            Box box = new Box(l, w, h);

            Display(box);
            Console.WriteLine($"The volume of your box is: {box.GetVolume()}.");
            
            Box box2 = new Box(2, 3, 4);
            Console.WriteLine(box2.GetVolume());

            Box box3 = Box.SumBoxes(box, box2);
            Display(box3);


            //pause program execution
            Console.WriteLine();
            Console.ReadLine();
        }

        public static void Display(Box box)
        {
            Console.WriteLine($"\nBox dimensions:\nLength {box.Length};\nWidth {box.Width};\nHeight {box.Height};\nVolume {box.Volume}.");
        }
    }
}
