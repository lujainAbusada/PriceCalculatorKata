using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class PurchaseReport
    {
        private PriceCalculator _priceCalculator;

        public PurchaseReport()
        {

        }
        public PurchaseReport(PriceCalculator priceCalculator)
        {
            this._priceCalculator = priceCalculator;
        }

        public void PrintReport()
        {
            Console.WriteLine($"Price = {_priceCalculator.FinalPrice}");
            Console.WriteLine(DiscountStringFormatter());
        }

        public string DiscountStringFormatter()
        {

            if (this._priceCalculator.DeducedPriceAmount == 0)
                return "";
            else
                return $"{this._priceCalculator.DeducedPriceAmount} was deduced form the original price";
        }
    }
}
