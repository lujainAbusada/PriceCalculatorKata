using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    interface IDiscountCalculator
    {
        public double PriceBeforeDiscount { get; }
        public double CalculateTotalDiscount(double price);
        public double CalculateUpcAndUniversalBeforeTax(double price);
        public double CalculateUpcAfterAndUniversalBeforeTax(double price);
        public double CalculateUpcBeforeAndUniversalAfterTax(double price);
        public double CalculateUpcAndUniversalAfterTax(double price);
    }
}
