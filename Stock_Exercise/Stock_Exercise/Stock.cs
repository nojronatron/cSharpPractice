using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Exercise
{
    class Stock
    {
        // Fields
        private string _companyName;
        private int _numberOfShares;
        private double _pricePerShare;
        // CTORs
        public Stock() { }
        public Stock(string companyName, int numberOfShares, double pricePerShare)
        {
            _companyName = companyName;
            _numberOfShares = numberOfShares;
            _pricePerShare = pricePerShare;
        }
        // Properties
        public string CompanyName { get { return _companyName; } }
        public int NumberOfShares { get { return _numberOfShares; } }
        public double PricePerShare { get { return _pricePerShare; } }
        // Methods
        public void BuyShares(int numShares)
        {
            _numberOfShares += numShares;
        }
        public bool SellShares( int numShares)
        {
            if (numShares <= _numberOfShares)
            {
                _numberOfShares -= numShares;
                return true;
            }
            return false;
        }
        // OverrideMethods
        public override string ToString()
        {
            return $"Name: {CompanyName, -20}\tShares: {NumberOfShares, -15}\tPricePerShare: {PricePerShare:C}";
        }
    }
}
