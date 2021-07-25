using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal class Currency
    {
        private readonly string _name;

        public string Name { get => _name; }

        public Currency(string currency)
        {
            _name = currency;
        }
    }
}
