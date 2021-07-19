using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Currency
    {
        private string _name;

        public string Name { get => _name; }

        public Currency(string currency)
        {
            _name = currency;
        }
    }
}
