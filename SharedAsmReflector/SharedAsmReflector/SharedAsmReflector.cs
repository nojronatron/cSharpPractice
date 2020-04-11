using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace SharedAsmReflector
{
    class SharedAsmReflector
    {
        private static void DisplayInfo(Assembly a)
        {
            Console.WriteLine("***** Info about Assembly *****");
            Console.WriteLine($"Loaded from GAC? { a.GlobalAssemblyCache }");
            Console.WriteLine($"Asm Name: { a.GetName().Name }");
            Console.WriteLine($"Asm Version: { a.GetName().Version }");
            Console.WriteLine($"Asm Culture: { a.GetName().CultureInfo.DisplayName }");
            Console.WriteLine("\nHere are the public enums:");

            //  use LINQ to find the public enums
            Type[] types = a.GetTypes();
            var publicEnums = from pe in types
                              where pe.IsEnum && pe.IsPublic
                              select pe;

            foreach (var pe in publicEnums)
            {
                Console.WriteLine(pe);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Shared Assembly Reflector App (Chapter 15) *****");

            //  load System.Windows.Forms.dll from GAC
            string displayName = string.Empty;
            displayName = "System.Windows.Forms," + 
                          "Version=4.0.0.0," +
                          "PublicKeyToken=b77a5c561934e089," +
                          @"Culture=""";
            Assembly asm = Assembly.Load(displayName);
            DisplayInfo(asm);
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
