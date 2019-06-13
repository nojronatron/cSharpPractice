using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsHandling
{
    class OddNumberException : ArithmeticException
    {
        public OddNumberException() : base("Cannot evenly divide an odd number.") { }
        public OddNumberException(string message) : base(message) { }
        public OddNumberException(string message, Exception innerException) : base(message, innerException) { }
    }
}
