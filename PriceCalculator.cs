using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    
    class PriceCalculator
    {
        private double _taxAmount;
        private Product _purchasedProduct;
        private double _finalPrice;
        private double _discountAmount;

        public PriceCalculator()
        {

        }

        public PriceCalculator(double tax,double discount, Product product)
        {
            this._purchasedProduct = product;
            this._taxAmount = tax;
            this._discountAmount = discount;
            this._finalPrice = this._purchasedProduct.Price;
        }

        public void TaxCalculator()
        {
               this._finalPrice = this._finalPrice + (this._purchasedProduct.Price * this._taxAmount);
               this._finalPrice= Math.Round(this._finalPrice, 2);
        }

        public void DiscountCalculator()

        {
            this._finalPrice = this._finalPrice - (this._purchasedProduct.Price * this._discountAmount);
            this._finalPrice=Math.Round(this._finalPrice, 2);
        }

        public double FinalPrice()
        {
            TaxCalculator();
            DiscountCalculator();
            return this._finalPrice;
        }
    }
}
