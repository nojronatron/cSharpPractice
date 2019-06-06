using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overriding_Equals_Method
{
    public class Box
    {
        // Fields
        private string _name;
        private int _length;
        private int _width;
        private int _height;
        // CTORs
        public Box() { }
        public Box(int length, int width, int height, string name)
        {
            _length = length;
            _width = width;
            _height = height;
            _name = name;
        }
        public string Name { get { return _name; } set { _name = value; } }
        // Properties not required to meet goals of this in-class exercise
        // Override ToString() inherited automatically from Object
        public override string ToString()
        {   // Instead of writing to console from the class (bad)
            //    return a string that the user/Main can decide what to do with
            //    and the UI isn't of concern for the Class
            return $"Name: {_name}\tL: {_length}\tW: {_width}\tH: {_height}";
        }
        public override bool Equals(object obj)
        {
            Box b = (Box)obj; // Explicit caste of obj to Box
            // are they referencing the same box e.g.:Same reference address?
            if(this == b) { return true; }
            // since they are not test their Fields to equality using AND logic
            if (this._length == b._length && this._width == b._width && this._height == b._height) { return true; }
            else { return false; }
        }
    }
}
