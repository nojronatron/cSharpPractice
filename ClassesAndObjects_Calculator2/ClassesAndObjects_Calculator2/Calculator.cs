using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects_Calculator2
{
    class Calculator
    {
        private int alpha;
        private int bravo;

        public Calculator(int a, int b)
        {
            // Constructor
            this.alpha = a;
            this.bravo = b;
        }

        public Calculator(Calculator c)
        {
            // Copy Constructor
            this.alpha = c.alpha;
            this.bravo = c.bravo;
        }

        public Calculator()
        {
            // Default Constructor
            this.alpha = 1;
            this.bravo = 1;
        }

        public int Add()
        {
            // Addition (sum) Method
            return this.alpha + this.bravo;
        }

        public int Multiply()
        {
            // Multiplication Method
            return this.alpha * this.bravo;
        }
    }
}
