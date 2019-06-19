using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace CustomInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Interfaces *****");
            // Call Points property defined by IPointy
            Hexagon hex = new Hexagon();

            Console.WriteLine($"Points: {hex.Points}");

            // If you don't know if the Interface has been implemented you can try to use an explicit cast with a try/catch
            Circle c = new Circle("Lisa");
            IPointy itfPt = null;
            try
            {
                Console.WriteLine("Attempting to cast Circle as an IPointy type itfPt");
                itfPt = (IPointy)c;
                Console.WriteLine(itfPt.Points);
            }
            catch (InvalidCastException icEx)
            {
                Console.WriteLine($"\n{icEx.Message}");
                // but there are other ways
            }

            // If you don't know at runtime if the instance implements an Interface, try casting the interface using the AS keyword
            Circle c2 = new Circle("Cindy");
            CheckAsPointy(c2);
            Hexagon h2 = new Hexagon("Henrietta");
            CheckAsPointy(h2);

            // If you don't know at runtime if the instance implements an Interface, try casting the interface using the IS keyword
            Circle c3 = new Circle("Charles");
            Hexagon h3 = new Hexagon("Harry");
            CheckIsPointy(c3);
            CheckIsPointy(h3);



            // pause program execution before exiting
            Console.Write("\n\nPress <Enter> Key to Exit. . .");
            Console.ReadLine();
        }
        public static void CheckIsPointy(Shape s)
        {
            if (s is IPointy ip)
            {
                Console.WriteLine($"\n{s.PetName} has {ip.Points} points.");
            }
            else
            {
                Console.WriteLine($"\n{s.PetName} {s.GetType().Name} does not implement the IPointy Interface.");
            }
        }
        public static void CheckAsPointy(Shape s)
        {
            IPointy anyPoints = s as IPointy;
            if (anyPoints == null)
            {
                Console.WriteLine($"\n{s.PetName} {s.GetType().Name} does not implement the IPointy Interface.");
            }
            else
            {
                Console.WriteLine($"\n{s.PetName} has {anyPoints.Points} points.");
            }
        }
    }
}
