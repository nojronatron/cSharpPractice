using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCSharpApp
{
    class Program
    {
        static int Main(string[] args)
        {   // This is the Application Object and main entry point into the program
            //   Other entry point(s) could be made but must be referenced in the command-line compiler or th eStarup Object drop-down
            //   string[] args will accept command-line arguments upon execution
            // Display a simple message to the user.
            Console.WriteLine("***** Not my first C# App *****");
            Console.WriteLine("Hello World!");
            Console.WriteLine();

            // Wait for Enter key to be pressed before shutting down.
            Console.ReadLine();

            // Return an arbitrary int value a.k.a. error code
            return 0;
        }
    }
}
