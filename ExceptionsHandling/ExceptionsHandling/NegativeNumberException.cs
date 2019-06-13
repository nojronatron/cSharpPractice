using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsHandling
{
    class NegativeNumberException: ArithmeticException
    {
        public NegativeNumberException() : base("Cannot get the square root of a negative number") { }
        public NegativeNumberException(string message) : base(message) { }
        public NegativeNumberException(string message, Exception innerException) : base(message, innerException) { }
    }
}
