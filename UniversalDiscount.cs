using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{

    internal class UniversalDiscount : IDiscount
    {
        private readonly double _amount;
        private double _priceAfterDiscount;
        private double _deducedPriceAmount;
        private readonly DiscountType _type;

        public double Amount { get => _amount; }
        public double PriceAfterDiscount { get => _priceAfterDiscount; }
        public double DeducedPriceAmount { get => _deducedPriceAmount; }
        public DiscountType Type { get => _type; }

        public UniversalDiscount(double amount, DiscountType type)
        {
            _amount = amount;
            _type = type;
        }

        public double CalculateDiscount(double price)
        {
            _deducedPriceAmount = Math.Round(price * Amount, 4);
            _priceAfterDiscount = price - _deducedPriceAmount;
            return _deducedPriceAmount;
        }
    }
}
