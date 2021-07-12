using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    
    class PriceCalculator
    {
        private double _taxAmount;
        private Product _purchasedProduct;

        public PriceCalculator()
        {

        }

        public PriceCalculator(double tax, Product product)
        {
            this._purchasedProduct = product;
            this._taxAmount = tax;

        }

        public double TaxCalculator()
        {
               double priceAferTax= this._purchasedProduct.Price + (this._purchasedProduct.Price * this._taxAmount);
               return Math.Round(priceAferTax, 2);
        }
    }
}
