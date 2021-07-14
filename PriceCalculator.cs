using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{

    class PriceCalculator
    {
        private double taxAmount;
        private Product purchasedProduct;
        private double finalPrice;
        private Discount discount;
        private double deducedPriceAmount = 0;
        private Expenses ExtraExpenses;


        public double TaxAmount { get => taxAmount; set => taxAmount = value; }
        internal Product PurchasedProduct { get => purchasedProduct; set => purchasedProduct = value; }
        public double FinalPrice { get => finalPrice; set => finalPrice = value; }
        public double DeducedPriceAmount { get => deducedPriceAmount; set => deducedPriceAmount = value; }
        internal Discount Amount { get => discount; set => discount = value; }
        internal Expenses ProductExtraExpenses1 { get => ExtraExpenses; set => ExtraExpenses = value; }

        public PriceCalculator()
        {

        }


        public PriceCalculator(double tax, Discount discount, Product product, Expenses expenses)
        {
            purchasedProduct = product;
            taxAmount = tax;
            this.discount = discount;
            finalPrice = this.purchasedProduct.Price;
            ExtraExpenses = expenses;
        }

        public double AddTax()
        {
            return Math.Round((finalPrice + (finalPrice * taxAmount)), 2);
        }

        public double AddUniversalDiscount(double price)

        {
            double discountedPrice = Math.Round(price * discount.UniversalAmount, 2);
            deducedPriceAmount += discountedPrice;
            return Math.Round(finalPrice - discountedPrice, 2);
        }

        public double AddUpcDiscount(double price)
        {
            double discountedPrice = Math.Round(price * discount.UpcAmount, 2);
            deducedPriceAmount += discountedPrice;
            return Math.Round(finalPrice - discountedPrice, 2);
        }

        public double AddTransportExpenses()
        {
            if (ExtraExpenses.CalculateTransportCost() == ExtraExpenses.TransportCost)
                return finalPrice += ExtraExpenses.TransportCost;
            else
                return finalPrice += purchasedProduct.Price * ExtraExpenses.TransportRate;
        }

        public double AddPackagingExpenses()
        {
            if (ExtraExpenses.CalculatePackagingCost() == ExtraExpenses.PackagingCost)
                return finalPrice += ExtraExpenses.PackagingCost;
            else
                return finalPrice += purchasedProduct.Price * ExtraExpenses.PackagingRate;
        }

        public double AddAdministrativeExpenses()
        {
            if (ExtraExpenses.CalculateAdministrativeCost() == ExtraExpenses.AdministrativeCost)
                return finalPrice += ExtraExpenses.AdministrativeCost;
            else
                return finalPrice += purchasedProduct.Price * ExtraExpenses.AdministrativeRate;
        }

        public double CalculateFinalPrice()
        {
            if (discount.UpcDiscountbeforeTax == true)
                finalPrice = AddUpcDiscount(PurchasedProduct.Price);
            if (discount.UniversalDiscountbeforeTax == true)
                finalPrice = AddUniversalDiscount(PurchasedProduct.Price);

            double temp = finalPrice;
            finalPrice = AddTax();

            if (discount.UniversalDiscountbeforeTax == false)
                finalPrice = AddUniversalDiscount(temp);

            if (discount.UpcDiscountbeforeTax == false)
                finalPrice = AddUpcDiscount(temp);
            finalPrice = AddPackagingExpenses();
            finalPrice = AddTransportExpenses();
            finalPrice = AddAdministrativeExpenses();
            finalPrice = Math.Round(finalPrice, 2);
            return finalPrice;
        }
    }
}
