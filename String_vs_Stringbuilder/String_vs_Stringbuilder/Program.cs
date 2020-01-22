using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace String_vs_Stringbuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            const int endCounter = 3_000;
            const bool skipString = true;
            const bool runTests = false;

            if (runTests)
            {
                string s = string.Empty;
                //  String object is immutable, and causes extra work to edit once it is created
                if (!skipString)
                {
                    sw.Start();
                    for (int i = 0; i < endCounter; i++)    //  30_000 take just over 1 second; 300_000 takes more than a few minutes and GC is very active
                    {
                        s += $"{i} ";
                    }
                    sw.Stop();
                    //Console.WriteLine($"Appended directly to a string: {s}");
                    Console.WriteLine($"\nTime elapsed: {sw.Elapsed}.");
                }

                //  StringBuilder creates an object with an initial space to it
                //  and it allows appending to the same object (it is mutable)
                //  saving time and resources
                StringBuilder sb = new StringBuilder();
                sw.Reset();
                sw.Start();
                for (int j = 0; j < endCounter; j++)  //  3_000_000 take just 1.5 seconds and is must faster than String
                {
                    sb.Append($"{j} ");
                }
                sw.Stop();
                //Console.WriteLine($"\nAppended to a StringBuilder object: {sb.ToString()}");
                Console.WriteLine($"\nTime elapsed: {sw.Elapsed}.");
            }
            Console.WriteLine();

            //  String.split() breaks a string into an array of chars according to a given list of separators e.x.: ,.;:" etc
            string today = "Monday, January 06, 2020";
            char[] separators = { ',', ' ', ';', ':', '.' };
            //string[] words = today.Split(separators);
            string[] words = today.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in words)
            {
                Console.Write($"{s}\n");
            }
            Console.WriteLine();


            Console.WriteLine("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
    }
}
