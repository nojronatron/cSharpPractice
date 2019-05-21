using System;

namespace CreateClassLab
{
    //TODO:  Create a class called Book in a separate code file called Book.cs with the following requirements:
    //          Class can only be accessible within the assembly.
    //          Contains one parameterless method called PrintBook that
    //              does not return a value. It should be accessible only within the 
    //              assembly with the following code:
    //                  A write statement to the Console window with the message:  
    //                      "This method will print book info." This message should
    //                      be displayed on a line by itself.
    
    class Book
    {
        public void PrintBook()
        {
            // parameterless method does not return a value
        }
    }


    class TestClass
    {
        static void Main()
        {
            //TODO:  Declare and create an instance of the Book class
            //          and call the PrintBook method.

            Book book = new Book();
            Console.WriteLine($"This method will print book info.");
            book.PrintBook();

            Console.Write("\nPRESS <ENTER> to end.");
            Console.ReadLine();
        }
    }
}
