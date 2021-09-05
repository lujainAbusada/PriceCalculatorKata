﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal class PurchaseReport
    {
        private readonly PriceCalculator _priceCalculator;

        public PurchaseReport(PriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator;
        }

        public void PrintReport()
        {
            Console.WriteLine($"Cost = {_priceCalculator.PurchasedProduct.Price} {_priceCalculator.Currency.Name}");
            Console.WriteLine($"Tax = {Math.Round(_priceCalculator.Tax.TaxAmount, 2)} {_priceCalculator.Currency.Name}");
            Console.WriteLine($"Transport Cost = {Math.Round(_priceCalculator.Expenses.TransportCost ,2)} {_priceCalculator.Currency.Name}");
            Console.WriteLine($"Packaging Cost = {Math.Round(_priceCalculator.Expenses.PackagingCost ,2)} {_priceCalculator.Currency.Name}");
            Console.WriteLine($"Administrative Cost = {Math.Round(_priceCalculator.Expenses.AdministrativeCost ,2)} {_priceCalculator.Currency.Name}");
            Console.WriteLine($"Total = {Math.Round(_priceCalculator.FinalPrice, 2)} {_priceCalculator.Currency.Name}");
            Console.WriteLine(DiscountStringFormatter());
        }

        public string DiscountStringFormatter()
        {
            return _priceCalculator.DeducedPriceAmount == 0 ? "" : $"{Math.Round(this._priceCalculator.DeducedPriceAmount, 2)} {_priceCalculator.Currency.Name} was deduced form the original price";
        }
    }
}
