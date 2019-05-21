using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstructorLab
{
    internal class Book
    {
        //TODO: Declare a private string type field
        //          for title.
        private string title;

        //TODO: Declare a constructor that has no parameters.
        //      Constructor is to store a book title into
        //          the field declared above.
        
        public Book(string title)
        {
            this.title = title;
        }

        internal void PrintBook()
        {
            //TODO:  Replace the following code line to display the 
            //          title using the "this" keyword.
            Console.WriteLine($"Book title: {this.title}.");
        }
    }
}
