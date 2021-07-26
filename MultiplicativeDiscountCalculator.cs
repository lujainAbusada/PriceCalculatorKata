using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculatorKata
{
    internal class MultiplicativeDiscountCalculator : IDiscountCalculator
    {
        private readonly List<IDiscount> _allDiscounts;


        public MultiplicativeDiscountCalculator(List<IDiscount> Discount)
        {
            _allDiscounts = Discount;
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
                deducedAmountAfterTax += Discount.CalculateDiscount(price - deducedAmountAfterTax);
            return deducedAmountAfterTax;
        }

        public double CalculateDiscountsbeforeTax(double price, List<IDiscount> discountsBeforeTax)
        {
            var deducedAmountBeforeTax = 0.0;
            foreach (IDiscount Discount in discountsBeforeTax)
                deducedAmountBeforeTax += Discount.CalculateDiscount(price - deducedAmountBeforeTax);
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
       