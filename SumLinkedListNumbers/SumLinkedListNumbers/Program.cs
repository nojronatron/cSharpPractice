using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumLinkedListNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are given two non - empty linked lists representing two non - negative integers.The digits are stored in reverse order and each of their nodes contain a single digit.Add the two numbers and return it as a linked list.
            //You may assume the two numbers do not contain any leading zero, except the number 0 itself.
            //Example:
            //Input: (2-> 4-> 3) +(5-> 6-> 4)
            //Output: 7-> 0-> 8
            //Explanation: 342 + 465 = 807.

            LinkedList<int> Llist1 = new LinkedList<int>();
            Llist1.AddFirst(2);
            Llist1.AddFirst(4);
            Llist1.AddFirst(3);

            LinkedList<int> Llist2 = new LinkedList<int>();
            Llist2.AddFirst(5);
            Llist2.AddFirst(6);
            Llist2.AddFirst(4);

            Console.WriteLine("***** Linked List Node Values *****");
            Console.WriteLine("\nLlist1 -->>");
            DisplayLLNodes(Llist1);
            Console.WriteLine("\nLlist2 -->>");
            DisplayLLNodes(Llist2);

            LinkedList<int> result = GetLLNodesSum(Llist1, Llist2);
            DisplayLLNodes(result);


            Console.Write("\nPress <Enter> to Exit. . .");
            Console.ReadLine();
        }
        static LinkedList<int> GetLLNodesSum(LinkedList<int> list1, LinkedList<int> list2)
        {
            int[] collector = new int[2];
            int tracker = 0;
            int result;
            List<LinkedList<int>> metalist = new List<LinkedList<int>>(2);
            metalist.Add(list1);
            metalist.Add(list2);
            foreach (LinkedList<int> list in metalist)
            {
                int mult = 1;
                LinkedListNode<int> temp = list.Last;
                while (temp != null)
                {
                    collector[tracker] += (temp.Value * mult);
                    temp = temp.Previous;
                    mult *= 10;
                }
                tracker++;
            }
            result = collector[0] + collector[1];
            LinkedList<int> resultLL = new LinkedList<int>();
            string strResult = result.ToString();
            for (int z = 0; z < strResult.Length; z++)
            {
                string strTemp = strResult.Substring(z, 1);
                resultLL.AddFirst(int.Parse(strTemp));
            }
            Console.WriteLine($"\nThe sum of {collector[0]} and {collector[1]} is {result}\n");
            return resultLL;
        }
        static void DisplayLLNodes(LinkedList<int> ll)
        {
            LinkedListNode<int> temp = ll.First;
            while(temp != null)
            {
                Console.WriteLine($" -> Node value: {temp.Value}");
                temp = temp.Next;
            }
            Console.WriteLine();
        }
    }
}
