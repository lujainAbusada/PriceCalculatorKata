using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculatorKata
{
    internal class AdditiveDiscountCalculator : IDiscountCalculator
    {
        private readonly List<IDiscount> _allDiscounts;
        private readonly UpcDiscount _upc;
        private readonly UniversalDiscount _universal;

        public AdditiveDiscountCalculator(List<IDiscount> Discount)
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
     
        public double CalculatePriceBeforeTax(double price)
        {
            if (_upc.Type == DiscountType.before && _universal.Type == DiscountType.before)
            {
                return price -_upc.CalculateDiscount(price) + _universal.CalculateDiscount(price);
            }
            else if (_upc.Type == DiscountType.before && _universal.Type == DiscountType.after)
            {
                return price - _upc.CalculateDiscount(price);
            }
            else if (_upc.Type == DiscountType.after && _universal.Type == DiscountType.before)
            {
                return price -  _universal.CalculateDiscount(price);
            }
            else
            {
                return price;
            }
        }
       
        public double CalculateUpcAndUniversalBeforeTax(double price)
        {
            return _upc.CalculateDiscount(price) + _universal.CalculateDiscount(price);
        }

        public double CalculateUpcAfterAndUniversalBeforeTax(double price)
        {
            var deducedAmount = _universal.CalculateDiscount(price);
            deducedAmount += _upc.CalculateDiscount(price - deducedAmount);
            return deducedAmount;
        }

        public double CalculateUpcBeforeAndUniversalAfterTax(double price)
        {
            var deducedAmount = _upc.CalculateDiscount(price);
            deducedAmount += _universal.CalculateDiscount(price - deducedAmount);
            return deducedAmount;
        }

        public double CalculateUpcAndUniversalAfterTax(double price)
        {
                return  _upc.CalculateDiscount(price) + _universal.CalculateDiscount(price);
        }
    }
}
