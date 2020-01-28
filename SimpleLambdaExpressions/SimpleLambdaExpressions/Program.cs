using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //  method of the System.Collection.Generic.List<T> class:
            //  public List<T> FindAll(Predicate<T> match)
            //      returns new List<T> that represents the subset of data
            //      Predicate<T> delegate type can point to any method returning a bool and takes a single type parameter
            //          as the only input param

            //  this delegate is used by thte FindAll() method to extract out the subset
            //  public delegater bool Predicate<T><T obj>

            Console.WriteLine("***** Fun with Lambdas *****\n");
            TraditionalDelegateSyntax();



            Console.Write("Press <Enter> to Exit. . .");
            Console.ReadLine();
        }
        static void TraditionalDelegateSyntax()
        {
            //  make a list of integers
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            //  call FindAll() using traditional delegate syntax
            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);

            Console.WriteLine("Here are your event numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.WriteLine($"{ evenNumber }\t");
            }
            Console.WriteLine();
        }
        //  target for the Predicate<> delegate
        static bool IsEvenNumber(int i)
        {
            //  is it an even number?
            return (i % 2 == 0);
        }
    }
}
