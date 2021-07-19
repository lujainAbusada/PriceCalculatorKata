using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class UpcDiscount : IDiscount
    {
        private double _amount;
        private double _priceAfterDiscount;
        private double _deducedPriceAmount;
        private bool _beforeTax;

        public double Amount { get => _amount; }
        public double PriceAfterDiscount { get => _priceAfterDiscount; }
        public double DeducedPriceAmount { get => _deducedPriceAmount; }
        public bool BeforeTax { get => _beforeTax; }

        public UpcDiscount(double amount, bool beforeTax)
        {
            _amount = amount;
            _beforeTax = beforeTax;
        }

        public double CalculateDiscount(double price)
        {
            _deducedPriceAmount = Math.Round(price * Amount, 4);
            _priceAfterDiscount = price - _deducedPriceAmount;
            return _deducedPriceAmount;
        }
    }
}