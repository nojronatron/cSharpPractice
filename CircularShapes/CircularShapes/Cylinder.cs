using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularShapes
{
    internal class Cylinder : Circle
    {
        // Fields
        // needs _radius and _height
        private double _height;
        // CTORS
        public Cylinder(double radius, double height) : base(radius)
        { // the Cylinder's Fields
            _height = height;
            // inherited Fields are Chained via base(Field)
        }
        // Properties
        public double Height
        {
            // this is required here for the this.Volume() method to use a Property (intead of the Field)
            get { return _height; }
        }
        // Methods
        public override double Area()
        {
            return 2*Math.PI*Radius*Height+(2*Math.PI*Math.Pow(Radius, 2));
        }
        public override double Volume()
        {
            return Math.PI*Math.Pow(Radius, 2)* Height;
        }
        public override string ToString()
        {
            return $"{GetType(),-15} radius: {Radius,-10} height: {Height,-10} perimeter: {Perimeter().ToString(),-15} area: {Area().ToString(),-15} volume: {Volume().ToString(),-15}";
        }
    }
}
