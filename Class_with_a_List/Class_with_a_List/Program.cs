using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_with_a_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Course csharp1 = new Course("1011", Session.Winter);
            // internally a gradeList was created, without the user/caller knowing

            // add a few grades to csharp1
            csharp1.AddGrade(100); // this method() has access to gradeList object
            csharp1.AddGrade(99);
            csharp1.AddGrade(98);
            csharp1.AddGrade(97);
            csharp1.AddGrade(96);
            csharp1.AddGrade(95);
            csharp1.RemoveGrade(85); // will be ignored even though it doesn't exist
            // csharp1.AddGrade(100); // should throw a custom exception; return a message

            // access the internal gradelist through the indexer
            // indexer allows us to use the instance csharp1 as an array
            // display all the grades in the list
            Console.WriteLine();
            for (int i = 0; i < csharp1.Count; i++)
            {
                Console.WriteLine($"{csharp1[i]}");
            }

            // display average, minimum, and maximum values in the list, without having direct access to it
            Console.WriteLine($"\nAverage: {csharp1.GetAverageGrade():f1}" +
                $"\tLowest: {csharp1.GetMinGrade():f1}" +
                $"\tHighest: {csharp1.GetMaxGrade():f1}\n");


            Console.WriteLine($"\ncsharp1.ToString(): {csharp1.ToString()}");


            Console.Write("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
    }
}
