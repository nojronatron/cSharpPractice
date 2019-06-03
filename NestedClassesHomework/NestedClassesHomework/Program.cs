using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedClassesHomework
{
    public class OuterClass
    {
        private int x;
        private int y;
        public void DisplaySelf()
        {
            Console.WriteLine("OuterClass here!");
        }
        public OuterClass(int X)
        {
            x = X;
            y = X;
        }
        public OuterClass() { }
        public int AddInnerClassFields()
        {
            // compile error should occur if 'total = a + b;' is attempted (IDE won't allow selecting a or b)
            return 0;
        }
        public class InnerClass
        {
            private int a;
            private int b;
            OuterClass outer;
            public InnerClass(int a, int b)
            {
                this.a = a;
                this.b = b;
            }
            public InnerClass() { }
            public InnerClass(OuterClass outer)
            {
                this.outer = outer;
            }
            public int AddOuterClassFields()
            {
                // 'int total = x + y;' compiler error (IDE won't allow selecting x or y)
                int total = outer.x + outer.y; // values will be 'null' however because 'outer' is not in the path!
                return total;
            }
            public void DisplaySelf()
            {
                Console.WriteLine("InnerClass here!");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OuterClass outer = new OuterClass(10);
            OuterClass.InnerClass inner = new OuterClass.InnerClass();
            OuterClass.InnerClass inner2 = new OuterClass.InnerClass(outer);
            outer.DisplaySelf();
            inner.DisplaySelf();
            Console.WriteLine($"Outer adding Inner Class Fields result: {outer.AddInnerClassFields()}");
            Console.WriteLine($"Inner adding Outer Class Fields result: {inner.AddOuterClassFields()}");
            Console.ReadLine();
        }
    }
}
