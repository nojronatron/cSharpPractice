using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree t = new Tree();

            t.Insert(50, "Dad");        // key is more important in this example
            t.Insert(49, "Mom");
            t.Insert(29, "Eldest Son");
            t.Insert(25, "Second Son");
            t.Insert(24, "Daughter");
            t.Insert(5, "Granddaughter");
            t.Insert(83, "Grandmother");
            t.Insert(81, "Grandfather");
            t.Insert(4, "Dog");

            Queue sortedTree = t.Inorder();
            DisplayResults(sortedTree, "Inorder");

            Queue preorderTree = t.Preorder();
            DisplayResults(preorderTree, "Preorder");

            Queue postorderTree = t.Postorder();
            DisplayResults(postorderTree, "Postorder");

            Queue outorderTree = t.OutOrder();
            DisplayResults(outorderTree, "Outorder");


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
            Console.WriteLine();

        }
    }
}
