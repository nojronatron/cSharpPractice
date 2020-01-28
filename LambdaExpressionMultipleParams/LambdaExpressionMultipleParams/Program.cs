using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionMultipleParams
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Register with delegate as a lambda expression
            SimpleMath m = new SimpleMath();
            m.SetMathHandler((msg, result) =>
            {
                Console.WriteLine($"Message: { msg }\tResult: { result }");
            });
            //  this will execute the Lambda expression
            m.Add(10, 10);



            Console.Write("\n\nPress <Enter> to Exit. . .");
            Console.ReadLine();
        }
    }
    public class SimpleMath
    {
        public delegate void MathMessage(string msg, int result);
        private MathMessage mmDelegate;

        public void SetMathHandler(MathMessage target)
        {
            mmDelegate = target;
        }

        public void Add(int x, int y)
        {
            mmDelegate?.Invoke("Adding has completed!", x + y);
        }
    }
}
