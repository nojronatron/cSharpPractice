using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetComputerInfo
{
    class Program
    {
        static int Main(string[] args)
        {
            // Helper method within the PROGRAM class
            Console.Clear();
            Console.WriteLine("***** Environment Details *****");
            ShowEnvironmentDetails();
            GetShowUserData();

            Console.WriteLine();
            Console.ReadLine();
            return -1;
        }

        static void GetShowUserData()
        {
            // change console colors
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            // gather user data
            Console.WriteLine("Please enter your name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Please enter your age:");
            string userAge = Console.ReadLine();

            // output user data
            Console.WriteLine($"Hello {userName}! You are {userAge} years old.");

            // restore previous color scheme
            Console.ForegroundColor = prevColor;
        }
        static void ShowEnvironmentDetails()
        {
            // Print out hte drives on this machines and other interesting details
            Console.WriteLine("\nDRIVES:");
            foreach (string drive in Environment.GetLogicalDrives())
                Console.WriteLine($"Drive: {drive}");

            Console.WriteLine();
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Version: {0}", Environment.Version);
        }
    }
}
