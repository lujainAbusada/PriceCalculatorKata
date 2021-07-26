using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculatorKata
{
    internal class AdditiveDiscountCalculator : IDiscountCalculator
    {
        private readonly List<IDiscount> _allDiscounts;

        public AdditiveDiscountCalculator(List<IDiscount> Discount)
        {
            _allDiscounts = Discount;
        }

        public double CalculateTotalDiscount(double price)
        {
            var discountBeforeTax = CalculateDiscountsbeforeTax(price, (from s in _allDiscounts
                                                                        where s.Type.Equals(DiscountType.before)
                                                                        select s).ToList());
            var discountAfterTax = CalculateDiscountsbeforeTax(price - discountBeforeTax, (from s in _allDiscounts
                                                                                           where s.Type.Equals(DiscountType.after)
                                                                                           select s).ToList());
            return discountAfterTax + discountBeforeTax;
        }

        public double CalculateDiscountsAfterTax(double price, List<IDiscount> discountsAfterTax)
        {
            var deducedAmountAfterTax = 0.0;
            foreach (IDiscount Discount in discountsAfterTax)
                deducedAmountAfterTax += Discount.CalculateDiscount(price);
            return deducedAmountAfterTax;
        }

        public double CalculateDiscountsbeforeTax(double price, List<IDiscount> discountsBeforeTax)
        {
            var deducedAmountBeforeTax = 0.0;
            foreach (IDiscount discount in discountsBeforeTax)
                deducedAmountBeforeTax += discount.CalculateDiscount(price);
            return deducedAmountBeforeTax;
        }

        public double CalculatePriceBeforeTax(double price)
        {
            return price - CalculateDiscountsbeforeTax(price, (from s in _allDiscounts
                                                               where s.Type.Equals(DiscountType.before)
                                                               select s).ToList());
        }
    }
}
