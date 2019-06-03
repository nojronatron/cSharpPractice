using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpOverloading_Cylinder
{
    class Cylinder
    {
        // Fields
        private double radius;
        private double height;
        public double Radius
        {
            get { return this.radius; }
            set { this.radius = value; }
        }
        public double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        public double Volume
        {
            get { return System.Math.PI * (System.Math.Pow(this.radius, 2)) * this.height; }
        }
        public double SurfaceArea
        {
            get { return (2 * System.Math.PI * radius * height) + (2 * System.Math.PI * (System.Math.Pow(radius, 2))); }
        }
        public Cylinder(double r, double h)
        {
            Radius = r;
            Height = h;
        }
        public Cylinder() { }
        public static Cylinder operator + (Cylinder c1, Cylinder c2)
        {
            Cylinder c = new Cylinder(c1.radius + c2.radius, c1.height + c2.height);
            return c;
        }
        public static Cylinder operator - (Cylinder c1, Cylinder c2)
        {
            if (c1.radius > c2.radius && c1.height > c2.height)
            {
                return new Cylinder(c1.radius - c2.radius, c1.height - c2.height);
            }
            else
            {
                return new Cylinder(0, 0);
            }
        }
        public static bool operator < (Cylinder c1, Cylinder c2)
        {
            if (c1.Volume < c2.Volume && c1.SurfaceArea < c2.SurfaceArea)
            {
                return true;
            }
            return false;
        }
        public static bool operator > (Cylinder c1, Cylinder c2)
        {
            if (c1.Volume > c2.Volume && c1.SurfaceArea > c2.SurfaceArea)
            {
                return true;
            }
            return false;
        }
        public static bool operator == (Cylinder c1, Cylinder c2)
        {
            if (c1.Volume == c2.Volume)
            {
                return true;
            }
            return false;
        }
        public static bool operator != (Cylinder c1, Cylinder c2)
        {

            if (c1.Volume == c2.Volume)
            {
                return false;
            }
            return true;
        }
    }
}