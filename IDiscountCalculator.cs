using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal interface IDiscountCalculator
    {
        public double CalculateTotalDiscount(double price);
        public double CalculatePriceBeforeTax(double price);
    }
}
