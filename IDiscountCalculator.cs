using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal interface IDiscountCalculator
    {
        public double PriceBeforeTax { get; }
        public double CalculateTotalDiscount(double price);
        public double CalculateUpcAndUniversalBeforeTax(double price);
        public double CalculateUpcAfterAndUniversalBeforeTax(double price);
        public double CalculateUpcBeforeAndUniversalAfterTax(double price);
        public double CalculateUpcAndUniversalAfterTax(double price);
    }
}
