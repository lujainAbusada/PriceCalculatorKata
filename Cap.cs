using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal class Cap
    {
        private double _capValue;
        private string _capString;
        private readonly string _percentage = "%";

        public Cap(string capString)
        {
            this._capString = capString;
        }

        public double CapValue { get => _capValue; }

        public double CalculateCap(double price)
        {
            if (_capString.Contains(_percentage))
            {
                _capString = _capString.Replace(_percentage, "");
                return _capValue = price * Double.Parse(_capString) / 100;
            }
            else
            {
                _capString = _capString.Replace("$", "");
                return _capValue = Double.Parse(_capString);
            }
        }
    }
}
