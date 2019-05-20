using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingCommandLineArguments
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("***** Regurgitate array of args *****\n");

            Console.WriteLine("Examine the incoming array of string data using different methods.\n");

            Console.WriteLine("Iterate through them using a FOR loop:");
            for (int i=0; i<args.Length; i++)
            {
                Console.WriteLine($"Arg{i}: {args[i]}");
            }

            Console.WriteLine("\nIterate through them using a FOREACH loop:");
            foreach (string arg in args)
                Console.WriteLine($"Arg: {arg}");

            Console.WriteLine("\nUse GetCommandLineArgs() method of ENVIRONMENT type");
            string[] theArgs = Environment.GetCommandLineArgs();
            foreach (string arg in theArgs)
                Console.WriteLine($"Arg: {arg}");

            Console.WriteLine();
            Console.ReadLine();
            return -1;
        }
    }
}
