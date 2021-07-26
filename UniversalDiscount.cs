using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal class UniversalDiscount : IDiscount
    {
        private readonly double _amount;
        private readonly DiscountType _type;

        public double Amount { get => _amount; }
        public DiscountType Type { get => _type; }

        public UniversalDiscount(double amount, DiscountType type)
        {
            _amount = amount;
            _type = type;
        }

        public double CalculateDiscount(double price)
        {
            return Math.Round(price * Amount, 4);
        }
    }
}
