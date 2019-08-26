using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterEvenNumbersFromListUsingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Filter out the first 3 even numbers from the list using LINQ
            List<int> list = new List<int>(10)
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            List<int> filteredList = iterFilter(list);
            Console.WriteLine($"*** Filtered List using List<int> iterators ***");
            DisplayList(filteredList);

            Console.WriteLine($"*** Filtered List using Linq Queries ***");
            List<int> linqFilteredList = linqFilter(list);
            DisplayList(linqFilteredList);

            Console.WriteLine("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        static List<int> linqFilter(List<int> list)
        {
            List<int> evens = (from num in list
                            where (num % 2 == 0)
                            select num).ToList();   // 0, 2, 4, 6, 8
            evens.RemoveRange(0, 3);                // 6, 8
            List<int> odds = (from num in list
                            where (num % 2 != 0)
                            select num).ToList();   // 1, 3, 5, 7, 9
            List<int> concatList = evens.Concat(odds).ToList(); // 6, 8, 1, 3, 5, 7, 9
            return (from num in concatList
                    orderby num ascending
                    select num).ToList();           // 1, 3, 5, 6, 7, 8, 9
        }
        static void DisplayList(List<int> list)
        {
            foreach (int j in list)
            {
                Console.Write($"{j}\t");
            }
            Console.WriteLine();
        }
        static List<int> iterFilter(List<int> list)
        {
            List<int> filteredList = new List<int>();
            int counter = 0;
            foreach (int i in list)
            {
                int result = i % 2;
                if (i >= 2)
                {
                    if (result == 0)
                    {
                        counter++;
                        if (counter > 3)
                        {
                            filteredList.Add(list[i]); // 8,
                        }
                    } // dropped: 2, 4, 6
                    else
                    {
                        filteredList.Add(list[i]); // 9,
                    }
                }
                else
                {
                    filteredList.Add(list[i]); // 0, 1, 3, 5, 7
                }
            }
            return filteredList;
        }
    }
}
