using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPreviewMimic
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1a.	Prompt the user for all the sending information and return address information. 
            // 1b.  Store this information is variables of type string.
            // 2a.	Display the information the user entered to the console window. 
            // 2b.  As part of the display, reformat it to look like the output below.

            Console.Title = "Print Preview Mimic";  //  Added per Pro C# 7 book text
            // Gather User Input
            Console.Write("Enter the Addressee's Name: ");
            string dest_person = Console.ReadLine();
            Console.Write("Enter Destination House Number and Street Address: ");
            string dest_addr = Console.ReadLine();
            Console.Write("Enter the Destination City, State, and Zip Code: ");
            string dest_citystatezip = Console.ReadLine();

            Console.Write("Enter the Return Address Person Name: ");
            string return_person = Console.ReadLine();
            Console.Write("Enter the Return Address: ");
            string return_addr = Console.ReadLine();
            Console.Write("Enter the return city, state, and zip code: ");
            string return_citystatezip = Console.ReadLine();

            // Output
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 87; i++)
            {
                Console.Write("*");
            }
            Console.SetCursorPosition(0, 12);
            for (int i = 0; i < 87; i++)
            {
                Console.Write("*");
            }
            Console.SetCursorPosition(0, 1);
            // Return Address
            Console.WriteLine($"{return_person}\n{return_addr}\n{return_citystatezip}");

            // Destination Address
            Console.SetCursorPosition(32, 6);
            Console.WriteLine($"{dest_person}");
            Console.SetCursorPosition(32, 7);
            Console.WriteLine($"{ dest_addr}");
            Console.SetCursorPosition(32, 8);
            Console.WriteLine($"{dest_citystatezip}");

            // Pause program execution
            Console.SetCursorPosition(0, 15);
            Console.Write("Press Enter Key to Continue . . .");
            Console.ReadLine();
        }
    }
}
