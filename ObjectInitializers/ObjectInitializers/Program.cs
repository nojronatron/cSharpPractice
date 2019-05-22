using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    enum PointColor
    {
        LightBlue, BloodRed, Gold
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointColor Color { get; set; }  // Accessor for the PointColor ENUM

        public Point(int xVal, int yVal)
        {
            X = xVal;
            Y = yVal;
            Color = PointColor.Gold;  // Requires an Accessor
        }

        public Point(PointColor ptColor) {
            Color = ptColor;
        }  //  Default values for int: zero, so no entries needed

        public Point() : this(PointColor.BloodRed) { }

        public void DisplayStats()
        {
            Console.WriteLine($"[{X}, {Y}]");
            Console.WriteLine($"Point is {Color}.");
        }
    }

    class Rectangle
    {
        private Point topLeft = new Point();
        private Point bottomRight = new Point();

        public Point TopLeft
        {
            get { return topLeft; }
            set { topLeft = value; }
        }
        public Point BottomRight
        {
            get { return bottomRight; }
            set { bottomRight = value; }
        }

        public void DisplayStats()
        {
            Console.WriteLine($"[TopLeft: {topLeft.X}, {topLeft.Y}, {topLeft.Color} " +
                $"BottomRight: {bottomRight.X}, {bottomRight.Y}, {bottomRight.Color}]");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a point by setting each property manually:");
            Point p = new Point();
            p.X = 1;
            p.Y = 2;
            p.DisplayStats();

            Console.WriteLine("Create a point via the Custom Constructor:");
            Point q = new Point();
            q.DisplayStats();

            Console.WriteLine("Create a point using the object init syntax:");
            Point r = new Point { X = 30, Y = 30 }; // Implicitly calling Default Constructor then setting Properties
            r.DisplayStats();

            Console.WriteLine("Now change the point Color using a Custom Constructor plus Specified Properties (default is BloodRed):");
            Point goldPoint = new Point(PointColor.Gold) { X = 90, Y = 20 };
            goldPoint.DisplayStats();

            Console.WriteLine("Create a new Rectangle variable and set the inner Points");
            Rectangle myRect = new Rectangle
            {
                TopLeft = new Point { X = 10, Y = 10 },
                BottomRight = new Point { X = 200, Y = 200 }
            };
            myRect.DisplayStats();

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
