using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal class PriceCalculator
    {
        private readonly Product _purchasedProduct;
        private readonly Expenses _expenses;
        private readonly Cap _cap;
        private readonly Tax _tax;
        private readonly Currency _currency;
        private readonly IDiscountCalculator _discount;
        private double finalPrice;
        private double _deducedPriceAmount = 0;
        private double _priceBeforeTax;

        public double FinalPrice { get => finalPrice; }
        internal Product PurchasedProduct { get => _purchasedProduct; }
        internal Tax Tax { get => _tax; }
        internal Currency Currency { get => _currency; }
        public double DeducedPriceAmount { get => _deducedPriceAmount; }
        internal Expenses Expenses => _expenses;

        public PriceCalculator(Product product, Tax tax, IDiscountCalculator discountCalculator, Expenses expenses, Currency currency, Cap cap)
        {
            _purchasedProduct = product;
            _tax = tax;
            finalPrice = _purchasedProduct.Price;
            _currency = currency;
            _cap = cap;
            _expenses = expenses;
            _priceBeforeTax = _purchasedProduct.Price;
            _discount = discountCalculator;
        }

        public double CalculateFinalPrice()
        {
            _deducedPriceAmount = _discount.CalculateTotalDiscount(_purchasedProduct.Price);
            CheckCap();
            _priceBeforeTax = _discount.CalculatePriceBeforeTax(_purchasedProduct.Price);
            finalPrice += _tax.CalculateTax(_priceBeforeTax) - _deducedPriceAmount + Expenses.CalculateTotalExpenses(_purchasedProduct.Price);
            return Math.Round(finalPrice, 2);
        }

        private void CheckCap()
        {
            if (_deducedPriceAmount > _cap.CalculateCap(_purchasedProduct.Price))
                _deducedPriceAmount = _cap.CalculateCap(_purchasedProduct.Price);
        }
    }
}
