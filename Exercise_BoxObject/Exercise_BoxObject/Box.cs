using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_BoxObject
{
    public class Box
    {
        private int length;
        private int width;
        private int height;

        public Box(int length, int width, int height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public Box()
        {
            this.length = 3;
            this.width = 4;
            this.height = 5;
        }

        public int Length { get { return this.length; } }
        public int Width { get { return this.width; } }
        public int Height {  get { return this.height; } }

        public decimal GetVolume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
