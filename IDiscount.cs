using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    interface IDiscount
    {
        public double Amount { get; }
        public double PriceAfterDiscount { get; }
        public double DeducedPriceAmount { get; }
        public bool BeforeTax { get; }
        public double CalculateDiscount(double price);
    }
}
