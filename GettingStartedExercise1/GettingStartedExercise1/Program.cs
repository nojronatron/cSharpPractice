using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            // INPUT
            // 1. Prompt the user for their first name. The prompt would say something like "Please enter your name: ".
            Console.WriteLine("Please enter your first name: ");
            string user_first_name = Console.ReadLine();

            // 2. Prompt the user for their nickname. The prompt would say something like "Please enter your nickname: ".
            Console.WriteLine("Please enter your nickname: ");
            string user_nickname = Console.ReadLine();

            // OUTPUT
            // 3. Display a message back to the user with the data they typed in. For example, you could say something like
            // "Hi Kevin. Can I call you Kev? ", where Kevin and Kev were the inputs given by the user.
            Console.WriteLine($"Hello {user_first_name}. Can I call you {user_nickname}?");

            // Pause execution before exiting
            Console.Write("\nPress Enter Key to Quit . . .");
            Console.ReadLine();
        }
    }
}
