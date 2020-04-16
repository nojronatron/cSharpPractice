using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ to Objects *****");
            Console.WriteLine("\nUsing basic Query Expression . . .");
            QueryOverStrings();

            Console.WriteLine("\nUsing Extension Methods . . .");
            QueryOverStringsWithExtensionMethods();

            Console.WriteLine("\nUsing the Long-form Way . . .");
            QueryOverStringsLongHand();

            Console.WriteLine("\nQuery Over Ints . . .");
            QueryOverInts();

            Console.WriteLine("\nQuery Over Ints using VAR . . .");
            QueryOverIntsImplictType();

            Console.WriteLine("\nLINQ Deferred Execution . . .");
            QueryOverIntsDeferredExecution();

            Console.WriteLine("\nLINQ Immediate Execution . . .");
            ImmediateExecution();
            Console.WriteLine("Each LINQ statement is wrapped in () and ends in .ToList<T>() or .ToArray<T>() . . .");

            Console.WriteLine("\nLINQ Return values. . .");
            foreach (string color in GetStringSubset())
            {
                Console.WriteLine($"=> { color }");
            }



            Console.WriteLine("\n\nPress <Enter> to Exit . . .");
            Console.ReadLine();
        }
        public static IEnumerable<string> GetStringSubset()
        {
            string[] colors = { "Red", "Green", "Yellow", "Purple", "Dark Red", "Blue", "Hazel", "Beige", "Light Red" };

            //  note subset is an IEnumerable<string>-compatible object
            IEnumerable<string> theRedColors = from color in colors
                                               where color.Contains("Red")
                                               select color;
            return theRedColors;
        }
        public static void ImmediateExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            //  get data NOW as an int[]
            int[] subsetIntArray = (from i in numbers
                                    where i < 10
                                    select i).ToArray<int>();

            //  get data NOW as a List<int>
            List<int> subsetIntList = (from i in numbers
                                       where i < 10
                                       select i).ToList<int>();
        }
        public static void QueryOverIntsDeferredExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            //  print only items less than 10
            var subset = from i in numbers
                         where i < 10
                         select i;

            foreach (var i in subset)
            {
                Console.WriteLine($"{ i } < 10");
            }
            Console.WriteLine();

            //  change a number in the array
            numbers[1] = 5;

            //  fresh LINQ evaluation
            foreach(var j in subset)
            {
                Console.WriteLine($"{ j } < 10");
            }
            Console.WriteLine();
        }
        public static void QueryOverIntsImplictType()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            //  print only items less than 10
            var subset = from i in numbers
                         where i < 10
                         select i;

            foreach (var i in subset)
            {
                Console.WriteLine($"Item: { i }");
            }
            ReflectOverQueryResults(subset);
        }
        public static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            //  print only items less than 10
            IEnumerable<int> subset = from i in numbers
                                      where i < 10
                                      select i;

            foreach(int i in subset)
            {
                Console.WriteLine($"Item: { i }");
            }
            ReflectOverQueryResults(subset);
        }
        public static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
        {
            Console.WriteLine($"*** Info about your query using { queryType } ***");
            Console.WriteLine($"resultSet is of type: { resultSet.GetType().Name }");
            Console.WriteLine($"resultSet location: { resultSet.GetType().Assembly.GetName().Name }");
        }
        public static void QueryOverStringsLongHand()
        {
            //  assume there is an array of strings
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            string[] gamesWithSpaces = new string[5];
            for (int i=0; i<currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                {
                    gamesWithSpaces[i] = currentVideoGames[i];
                }
            }

            //  sort the new array
            Array.Sort(gamesWithSpaces);

            //  print out the results
            foreach (string s in gamesWithSpaces)
            {
                if (s != null)
                {
                    Console.WriteLine($"Item: { s }");
                }
            }
        }
        public static void QueryOverStringsWithExtensionMethods()
        {
            //  assume there is an array of strings
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            //  build a query expression to find the items in the array that have an embedded space
            IEnumerable<string> subset = currentVideoGames.Where(game => game.Contains(" "))
                                                          .OrderBy(game => game)
                                                          .Select(game => game);

            //  print out the results
            foreach (string s in subset)
            {
                Console.WriteLine($"Item: { s }");
            }
        }
        public static void QueryOverStrings()
        {
            //  assume there is an array of strings
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            //  build a query expression to find the items in the array that have an embedded space
            IEnumerable<string> subset = from game in currentVideoGames
                                         where game.Contains(" ")
                                         orderby game
                                         select game;

            //  reflect over query results
            Console.WriteLine();
            ReflectOverQueryResults(subset);
            Console.WriteLine();

            //  print out the results
            foreach (string s in subset)
            {
                Console.WriteLine($"Item: { s }");
            }
        }
    }
}
