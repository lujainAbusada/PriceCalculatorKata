using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class PurchaseReport
    {
        private PriceCalculator _priceCalculator;
        private string _currency;

        public PurchaseReport()
        {

        }
        public PurchaseReport(PriceCalculator priceCalculator, string currency)
        {
            _priceCalculator = priceCalculator;
            _currency = currency;
        }

        public void PrintReport()
        {
            Console.WriteLine($"Cost = {_priceCalculator.PurchasedProduct.Price} {_currency}");
            Console.WriteLine($"Tax = {Math.Round(_priceCalculator.TaxAmount,2)} {_currency}");
            Console.WriteLine($"Total = {_priceCalculator.FinalPrice} {_currency}");
            Console.WriteLine(DiscountStringFormatter() );
        }

        public string DiscountStringFormatter()
        {

            if (this._priceCalculator.DeducedPriceAmount == 0)
                return "";
            else
                return $"{Math.Round(this._priceCalculator.DeducedPriceAmount,2)} {_currency} was deduced form the original price";
        }
    }
}
