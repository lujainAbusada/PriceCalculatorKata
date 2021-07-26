using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal class Cap
    {
        private readonly string _capValue;
        private const string _percentage = "%";

        public Cap(string capValue)
        {
            _capValue = capValue;
        }

        public double CalculateCap(double price)
        {
            return _capValue.Contains(_percentage) ? price * Double.Parse(_capValue.Replace(_percentage, "")) / 100 : Double.Parse(_capValue);
        }
    }
}
