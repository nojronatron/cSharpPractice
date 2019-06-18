using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Collection
{
    class Program
    {
        // The List<T> collection
        static List<int> numberList = new List<int>(); // creates a List<T> with the default capacity
        static Random rand = new Random();

        static void Main(string[] args)
        {
            int[] array = { 11, -22, -33, 44, 55};
            foreach (int value in array)
            {
                numberList.Add(value);
            }
            while (true)
            {
                Console.Clear();
                DisplayMenu();
                int selection;
                int.TryParse(Console.ReadLine(), out selection);
                Console.WriteLine();
                switch (selection)
                {
                    case 0: 
                        break;
                    case 1: // add new random value
                        {
                            // generate a random value, add it to the numberList, then display the numberList
                            int value = rand.Next(-99, 100);
                            numberList.Add(value);
                            DisplayList();
                        }
                        break;
                    case 2: // remove item by value
                        {
                            DisplayList();
                            int value;
                            try
                            {
                                Console.Write("\tEnter the value to remove: ");
                                value = int.Parse(Console.ReadLine());
                                numberList.Remove(value);
                                Console.WriteLine($"Item value {value} was removed.");
                            }
                            catch (ArgumentOutOfRangeException aoorEx)
                            {
                                Console.WriteLine($"\n{aoorEx.GetType().Name}\n{aoorEx.Message}");
                            }
                            DisplayList();
                        }
                        break;
                    case 3: // remove item by index
                        {
                            DisplayList();
                            int index;
                            try
                            {
                                Console.Write("\tEnter the index number of the item to remove: ");
                                index = int.Parse(Console.ReadLine()); // already have a try/catch so no need to TryParse
                                int item = numberList[index];
                                numberList.Remove(item);
                                Console.WriteLine($"Item value at index {index} was removed.");
                            }
                            catch (ArgumentOutOfRangeException aoorEx)
                            {
                                Console.WriteLine($"\n{aoorEx.GetType().Name}\n{aoorEx.Message}");
                            }
                            DisplayList();
                        }
                        break;
                    case 4: // remove the 1st and last items in the List<T>
                        {
                            DisplayList();
                            try
                            {
                                numberList.RemoveAt(0);
                                numberList.RemoveAt(numberList.Count - 1);
                            }
                            catch (ArgumentOutOfRangeException aoorEx)
                            {
                                Console.WriteLine($"\n{aoorEx.GetType().Name}\n{aoorEx.Message}");
                            }
                            Console.WriteLine("\nRemoving 1st and last items in the list...\n");
                            DisplayList();
                        }
                        break;
                    case 5: // get Average, Max, and Min numbers in the list
                        {
                            // via the Enumerable Class, methods() are available to do this work for us
                            if (numberList.Count > 0)
                            {
                                double avgValue = numberList.Average();
                                double minValue = numberList.Min();
                                double maxValue = numberList.Max();
                                // display results
                                Console.WriteLine($"\nAvg: {avgValue:f1}\tMin: {minValue:f1}\tMax: {maxValue:f1}");
                            }
                            else
                            {
                                Console.WriteLine($"\nUnable to calculate Avg, Min, and/or Max. Review the list to find out why.");
                                DisplayList();
                            }
                        }
                        break;
                    case 8: // display all items
                        {
                            DisplayList();
                        }
                        break;
                    case 9: // exit
                        {
                            return;
                        }
                }
                Console.WriteLine();
                Console.Write("Press <Enter> Key to Continue. . .");
                Console.ReadLine();
            }
        }
        static void DisplayList()
        {
            Console.WriteLine("\n***** List<T> Items and properties *****");
            foreach (int item in numberList)
            {
                Console.WriteLine($"Item => {item}");
            }
            Console.WriteLine($"\nCount: {numberList.Count}\tCapacity: {numberList.Capacity}\n");
            Console.WriteLine();
        }
        static void DisplayMenu()
        {
            Console.WriteLine("\t***** Menu *****\n");
            Console.WriteLine("\t1) Add new random value");
            Console.WriteLine("\t2) Remove by value");
            Console.WriteLine("\t3) Remove by index");
            Console.WriteLine("\t4) Remove the First and Last items");
            Console.WriteLine("\t5) Get Avg, Max, and Min values");
            Console.WriteLine("\t8) Display Items in List<T>");
            Console.WriteLine("\t9) Exit Program\n");
            Console.WriteLine("\t****************\n");
            Console.Write("\tMake A Selection: ");
        }
    }
}
