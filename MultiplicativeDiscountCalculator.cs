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
            if (_upc.Type == DiscountType.after && _universal.Type == DiscountType.before)
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
                var deducedAmount = _upc.CalculateDiscount(price);
                return price - deducedAmount - _universal.CalculateDiscount(price - deducedAmount);
            }
            else if (_upc.Type == DiscountType.before && _universal.Type == DiscountType.after)
            {
                return price - _upc.CalculateDiscount(price);
            }
            else if (_upc.Type == DiscountType.after && _universal.Type == DiscountType.before)
            {
                return price - _universal.CalculateDiscount(price);
            }
            else
            {
                return price;
            }
        }

        public double CalculateUpcAfterAndUniversalBeforeTax(double price)
        {
            var deducedAmount = _universal.CalculateDiscount(price);
            return deducedAmount + _upc.CalculateDiscount(price - deducedAmount);
        }

        public double CalculateUpcAndUniversalAfterTax(double price)
        {
             var deducedAmount = _upc.CalculateDiscount(price);
             return deducedAmount + _universal.CalculateDiscount(price - deducedAmount); ;
        }
    }
}
