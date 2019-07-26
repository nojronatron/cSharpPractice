using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables_InClassExercise
{
    public class Book
    {
        private string _title;
        private string _author;
        private string _publisher;
        private string _isbn;
        private decimal _price;

        public Book(string title, string author, string publisher, string isbn, decimal price)
        {
            this._author = author;
            this._title = title;
            this._price = price;
            this._isbn = isbn;
            this._publisher = publisher;
        }

        public string Title
        { get { return this._title; } }

        public string Author
        { get { return this._author; } }

        public string Publisher
        { get { return this._publisher; } }

        public string ISBN
        { get { return this._isbn; } }

        public decimal Price
        { get { return this._price; } }

        public override string ToString()
        {
            return $"{_title,-20}{_publisher,-20}{_author,-20}{_isbn,-20}{_price:c}";
        }
    }

}
