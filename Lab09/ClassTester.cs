using System;

namespace ConstructorLab
{
    
    class ClassTester
    {
        static void Main()
        {
            Book book = new Book("A C# Book");

            book.PrintBook();

            Console.Write("\nPRESS <ENTER> to end.");
            Console.ReadLine();
        }
    }
}
