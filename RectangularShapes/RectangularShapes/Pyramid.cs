using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangularShapes
{
    class Pyramid:Box
    {
        public Pyramid(double length, double width, double height) : base(length, width, height) { }
        public override double Area()
        {
            double A, equation1, equation2, equation3;
            equation1 = Length* Width;
            equation2 = Length * Math.Sqrt(Math.Pow((Width / 2D), 2) + Math.Pow(Height, 2));
            equation3 = Width * Math.Sqrt((Math.Pow((Length / 2D), 2) + Math.Pow(Height, 2)));
            A = equation1 + equation2 + equation3;
            return A;
        }
        public override double Volume()
        {
            return (Length * Width * Height) / 3D;
        }
    }
}
