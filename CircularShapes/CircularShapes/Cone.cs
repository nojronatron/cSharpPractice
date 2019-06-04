﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularShapes
{
    class Cone : Cylinder
    {
        public Cone(double radius, double height) : base(radius, height) { }
        public override double Area()
        {
            return Math.PI * Radius * (Radius + Math.Sqrt((Math.Pow(Height, 2) + Math.Pow(Radius, 2))));
        }
        public override double Volume()
        {
            return Math.PI * Math.Pow(Radius, 2) * (Height/3D);
        }
    }
}
