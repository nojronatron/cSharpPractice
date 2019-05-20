using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringComparisonEnumeration
{
    class Program
    {
        static void Main(string[] args)
        {
            // Rather than use string.ToUpper() and so-on to make copies of strings prior to manipulation and comparison:
            //     Use Equality/Rational Operators to do the work in a better performing, eaier to debug way.

            Console.WriteLine("***** String Equality (Case Insensitive *****");
            string s1 = "Hello!";
            string s2 = "HELLO!";
            Console.WriteLine($"s1 = {s1}; s2 = {s2}");
            Console.WriteLine();

            // check the results of changing the default compare rules
            Console.WriteLine($"Default rules: s1={s1}, s2={s2}, s1.Equals(s2): {s1.Equals(s2)}");

            Console.WriteLine($"Ignore case: s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {s1.Equals(s2, StringComparison.OrdinalIgnoreCase)}");

            Console.WriteLine($"Ignore case, Invariant Culture: s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase)}");

            Console.WriteLine();
            Console.WriteLine($"Default rules: s1={s1}, s2={s2} s1.indexOf(\"E\"): {s1.IndexOf("E")}");

            Console.WriteLine($"Ignore case: s1.IndexOf(\"E\", StringComparison.OrdinalIgnoreCase): {s1.IndexOf("E", StringComparison.OrdinalIgnoreCase)}");

            Console.WriteLine($"Ignore case, Invariant Culture: s1.IndexOf(\"E\", StringComparison.InvariantCultureIgnoreCase): {s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase)}");
            
            // Pause program output before exit
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
