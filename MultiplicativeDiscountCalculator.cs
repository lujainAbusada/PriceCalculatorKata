using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculatorKata
{
    internal class MultiplicativeDiscountCalculator : IDiscountCalculator
    {
        private readonly List<IDiscount> _allDiscounts;
        private readonly UpcDiscount _upc;
        private readonly UniversalDiscount _universal;
        private double _priceBeforeTax;
        private double _deducedAmount = 0;

        public double PriceBeforeTax { get => _priceBeforeTax; }

        public MultiplicativeDiscountCalculator(List<IDiscount> Discount)
        {
            _allDiscounts = Discount;
            _upc = GetUpcDiscount(Discount);
            _universal = GetUniversalDiscount(Discount);
        }

        public UpcDiscount GetUpcDiscount(List<IDiscount> Discount)
        {
            return Discount.OfType<UpcDiscount>().First();
        }

        public UniversalDiscount GetUniversalDiscount(List<IDiscount> Discount)
        {
            return Discount.OfType<UniversalDiscount>().First();
        }

        public double CalculateTotalDiscount(double price)
        {
            if (_upc.Type == DiscountType.before && _universal.Type == DiscountType.before)
            {
                return CalculateUpcAndUniversalBeforeTax(price);
            }
            else if (_upc.Type == DiscountType.before && _universal.Type == DiscountType.after)
            {
                return CalculateUpcBeforeAndUniversalAfterTax(price);
            }
            else if (_upc.Type == DiscountType.after && _universal.Type == DiscountType.before)
            {
                return CalculateUpcAfterAndUniversalBeforeTax(price);
            }
            else
            {
                return CalculateUpcAndUniversalAfterTax(price);
            }
        }

        public double CalculateUpcAndUniversalBeforeTax(double price)
        {
            _deducedAmount += _upc.CalculateDiscount(price);
            _deducedAmount += _universal.CalculateDiscount(price - _deducedAmount);
            _priceBeforeTax = price - _deducedAmount;
            return _deducedAmount;
        }

        public double CalculateUpcAfterAndUniversalBeforeTax(double price)
        {
            _deducedAmount = _universal.CalculateDiscount(price);
            _priceBeforeTax = price - _deducedAmount;
            _deducedAmount += _upc.CalculateDiscount(_priceBeforeTax);
            return _deducedAmount;
        }

        public double CalculateUpcBeforeAndUniversalAfterTax(double price)
        {
            _deducedAmount = _upc.CalculateDiscount(price);
            _priceBeforeTax = price - _deducedAmount;
            _deducedAmount += _universal.CalculateDiscount(_priceBeforeTax);
            return _deducedAmount;
        }

        public double CalculateUpcAndUniversalAfterTax(double price)
        {
            _deducedAmount += _upc.CalculateDiscount(price);
            _deducedAmount += _universal.CalculateDiscount(price - _deducedAmount);
            _priceBeforeTax = price;
            return _deducedAmount;
        }
    }
}
