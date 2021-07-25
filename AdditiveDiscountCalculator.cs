using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculatorKata
{
    internal class AdditiveDiscountCalculator : IDiscountCalculator
    {
        private readonly UpcDiscount _upc;
        private readonly UniversalDiscount _universal;
        private double _priceBeforeTax;
        private double _deducedAmount;

        public double PriceBeforeDiscount { get => _priceBeforeTax; }

        public AdditiveDiscountCalculator(List<IDiscount> Discount)
        {
            _upc = getUpcDiscount(Discount);
            _universal = getUniversalDiscount(Discount);
        }

        public UpcDiscount getUpcDiscount(List<IDiscount> Discount)
        {
            return Discount.OfType<UpcDiscount>().First();

        }

        public UniversalDiscount getUniversalDiscount(List<IDiscount> Discount)
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
            _deducedAmount = _upc.CalculateDiscount(price) + _universal.CalculateDiscount(price);
            _priceBeforeTax = price - _deducedAmount;
            return _deducedAmount;
        }

        public double CalculateUpcAfterAndUniversalBeforeTax(double price)
        {
            _deducedAmount = _universal.CalculateDiscount(price);
            _priceBeforeTax = price - _deducedAmount;
            return _deducedAmount += _upc.CalculateDiscount(_priceBeforeTax);
        }

        public double CalculateUpcBeforeAndUniversalAfterTax(double price)
        {
            _deducedAmount = _upc.CalculateDiscount(price);
            _priceBeforeTax = price - _deducedAmount;
            return _deducedAmount += _universal.CalculateDiscount(_priceBeforeTax);
        }

        public double CalculateUpcAndUniversalAfterTax(double price)
        {
            _deducedAmount = _upc.CalculateDiscount(price) + _universal.CalculateDiscount(price);
            _priceBeforeTax = price;
            return _deducedAmount;
        }
    }
}
