using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal class Cap
    {
        private string _capString;
        private const string _percentage = "%";

        public Cap(string capString)
        {
            this._capString = capString;
        }

        public double CalculateCap(double price)
        {
            return _capString.Contains(_percentage) ? price * Double.Parse(_capString.Replace(_percentage, "")) / 100 : Double.Parse(_capString);
        }
    }
}
