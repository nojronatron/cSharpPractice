using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_TowerOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Move a given number of disks stacked on one peg, to a different peg...
            //  ...by only stacking smaller discs on top of larger ones.
            //  Solve the problem piece-by-piece using recursion.
            //  Move the top n disks from peg 'from_peg' to peg 'to_peg'
            //  using peg 'other_peg' to hold disks temporarily as needed.
            Console.WriteLine("***** Fun with Recursion: Tower of Hanoi *****");
            int pegs = 3;
            Console.WriteLine($"\nThere are {pegs} pegs labeled 'A', 'B', and 'C'.");
            int discs;
            Console.Write("\nEnter the number of discs to shuffle (1 to 15; Default is 3): ");
            int.TryParse(Console.ReadLine(), out discs);

            //  test for and fix bad inputs
            if (discs <= 0) discs = 3;
            else if (discs > 15) discs = 3;
            Console.WriteLine($"Using {discs} discs...\n");

            //  execute!
            TowerOfHanoi("A", "B", "C", discs);

            Console.WriteLine("\n\nPress Enter to exit. . .");
            Console.ReadLine();
        }
        public static void TowerOfHanoi(string from_peg, string to_peg, string other_peg, int num_discs_to_move)
        {
            //  recursively move the top n-1 discs from 'from_peg' to 'other_peg'
            if (num_discs_to_move > 1)
            {
                TowerOfHanoi(from_peg, other_peg, to_peg, num_discs_to_move - 1);
            }

            //  move the last disk from from_peg to to_peg
            Console.WriteLine($"Move: {from_peg} => {to_peg}.");

            //  recursively move the top n-1 discs back from other_peg to to_peg
            if (num_discs_to_move > 1)
            {
                TowerOfHanoi(other_peg, to_peg, from_peg, num_discs_to_move - 1);
            }
        }
    }
}
