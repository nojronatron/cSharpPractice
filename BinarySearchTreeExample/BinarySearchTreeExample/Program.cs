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

            t.Insert(50, "Jon");        // key is more important in this example
            t.Insert(40, "Melissa");
            t.Insert(75, "Aaron");
            t.Insert(30, "Kris");
            t.Insert(45, "Sarah");
            t.Insert(20, "Kaylee");
            t.Insert(35, "Joan");

            Queue sortedTree = t.Inorder();

            Console.WriteLine("*** Inorder traversal results ***");
            foreach (DictionaryEntry de in sortedTree)
            {
                Console.WriteLine($"{de.Key}\t{de.Value}");
            }
            Console.WriteLine();

            Queue preorderTree = t.Preorder();
            Console.WriteLine("*** Preorder traversal results ***");
            foreach (DictionaryEntry de in preorderTree)
            {
                Console.WriteLine($"{de.Key}\t{de.Value}");
            }
            Console.WriteLine();

            Console.Write("\n\nPress <Enter> Key to Exit. . .");
            Console.ReadLine();
        }
    }
}
