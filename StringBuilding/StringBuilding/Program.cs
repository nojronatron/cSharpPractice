﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  //  StringBuilder lives here
using System.Threading.Tasks;

namespace StringBuilding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Using the StringBuilder *****");
            StringBuilder sb = new StringBuilder("***** Fantastic Games *****");
            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", " Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();

            // pause program execution before exiting
            Console.ReadLine();
        }
    }
}
