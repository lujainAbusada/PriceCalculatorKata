using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal interface IDiscount
    {
        public double CalculateDiscount(double price);
        public DiscountType Type { get; }
    }
}
