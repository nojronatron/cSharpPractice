using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_BoxObject
{
    public class Box
    {
        // private Fields: Length, Width, Height
        private int length; // int allows for up to 4 million values
        private int width;
        private int height;

        public Box(int length, int width, int height)
        {
            // Custom Constructor
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public Box()
        {
            // default Constructor
            this.length = 3;
            this.width = 4;
            this.height = 5;
        }

        // Properties - read only
        public int Length { get { return this.length; } }
        public int Width { get { return this.width; } }
        public int Height {  get { return this.height; } }

        // Method - computes and returns the volume of the box
        public decimal GetVolume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
