using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    
    class PriceCalculator
    {
        public double TaxAmount;
        public Product PurchasedProduct;
        public double FinalPrice;
        public double DiscountAmount;
        public double DeducedPriceAmount;

        public PriceCalculator()
        {

        }

        public PriceCalculator(double tax,double discount, Product product)
        {
            this.PurchasedProduct = product;
            this.TaxAmount = tax;
            this.DiscountAmount = discount;
            this.FinalPrice = this.PurchasedProduct.Price;
        }

        public void TaxCalculator()
        {
               this.FinalPrice = this.FinalPrice + (this.PurchasedProduct.Price * this.TaxAmount);
               this.FinalPrice= Math.Round(this.FinalPrice, 2);
        }

        public void DiscountCalculator()

        {
            DeducedPriceAmount = Math.Round(this.PurchasedProduct.Price * this.DiscountAmount,2);
            this.FinalPrice = Math.Round(this.FinalPrice - this.DeducedPriceAmount,2);
            this.FinalPrice=Math.Round(this.FinalPrice, 2);
        }

        public void CalculateFinalPrice()
        {
            TaxCalculator();
            DiscountCalculator();
        }
    }
}
