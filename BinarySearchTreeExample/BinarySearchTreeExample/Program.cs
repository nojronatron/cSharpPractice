using System;
using System.Collections;

namespace BinarySearchTreeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree t = new Tree();

            t.Insert(50, "Fifty");        // key is more important in this example
            t.Insert(20, "Fourty");
            t.Insert(100, "Seventy Five");
            t.Insert(10, "Thirty");
            t.Insert(5, "Fourty Five");
            t.Insert(6, "Twenty");
            t.Insert(7, "Thirty Five");
            t.Insert(8, "Seventy");
            t.Insert(9, "One Hundred");
            t.Insert(14, "Ninety");
            t.Insert(11, "One Hundred Fifty");
            t.Insert(12, "Sixty");
            t.Insert(13, "Seventy Two");

            Queue sortedTree = t.Inorder();
            DisplayResults(sortedTree, "Inorder");
            Console.ReadLine();

            Queue preorderTree = t.Preorder();
            DisplayResults(preorderTree, "Preorder");
            Console.ReadLine();

            Queue postorderTree = t.Postorder();
            DisplayResults(postorderTree, "Postorder");
            Console.ReadLine();

            Queue outorderTree = t.OutOrder();
            DisplayResults(outorderTree, "Outorder");
            Console.ReadLine();

            Console.WriteLine($"\n***** Fun with Max and Min *****");
            TreeNode maxnode = t.MaxNode();
            TreeNode minnode = t.MinNode();
            Console.WriteLine($"Max Node is: {maxnode.entry.Key} ({maxnode.entry.Value})");
            Console.WriteLine($"Min Node is: {minnode.entry.Key} ({minnode.entry.Value})");
            Console.ReadLine();

            Console.WriteLine("\n***** Search The BST *****");
            Console.Write("Enter the Key to search for: ");
            if (int.TryParse(Console.ReadLine(), out int response))
            {
                TreeNode foundNode = t.Get(response);
                if (foundNode == null)
                {
                    Console.WriteLine($"Could not find Key {response}");
                }
                else
                {
                    Console.WriteLine($"Found Key {foundNode.entry.Key} ({foundNode.entry.Value})");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Moving on...\n");
            }

            Console.WriteLine("\n***** Fun With Successor *****");
            Console.Write("Enter the Key to search for: ");
            if (int.TryParse(Console.ReadLine(), out int response2))
            {
                TreeNode foundNode = t.Get(response2);
                TreeNode successorNode = t.Successor(foundNode);
                Console.WriteLine($"Successor to {foundNode.entry.Key} is {successorNode.entry.Key} ({successorNode.entry.Value})");
            }
            else
            {
                Console.WriteLine("Invalid input. Moving on...\n");
            }
            Console.Write("\nLocate Successor to the Root node: ");
            TreeNode successor = t.Successor();
            Console.WriteLine($"Successor: {successor.entry.Key} ({successor.entry.Value})");
            Console.ReadLine();

            Console.WriteLine("\n***** Fun With Predecessor *****");
            TreeNode predecessorNode = t.Predecessor(t.Get(response2));
            Console.WriteLine($"Predecessor to {response2}: {predecessorNode.entry.Key} ({predecessorNode.entry.Value})");


            Console.Write("\n\nPress <Enter> Key to Exit. . .");
            Console.ReadLine();
        }
        static void DisplayResults(Queue q, string sortType)
        {
            Console.WriteLine($"*** {sortType} traversal results ***");
            foreach (DictionaryEntry de in q)
            {
                Console.WriteLine($"{de.Key}\t{de.Value}");
            }
            //while(q.Count > 0)
            //{
            //    DictionaryEntry de = (DictionaryEntry)q.Dequeue();
            //    Console.WriteLine($"{de.Key}\t{de.Value}");
            //}
            Console.WriteLine();
        }
    }
}
