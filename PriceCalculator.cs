using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{

    class PriceCalculator
    {
        private double _taxRate;
        private double taxAmount;
        private Product purchasedProduct;
        private Discount _discount;
        private Expenses _expenses;
        private double __deducedPriceFromUPCDiscount = 0;
        private double _deducedPriceFromUniversalDiscount = 0;
        private double deducedPriceAmount = 0;
        private double finalPrice;
 

        public double FinalPrice { get => finalPrice; set => finalPrice = value; }
        public double DeducedPriceAmount { get => deducedPriceAmount; set => deducedPriceAmount = value; }
        public double TaxAmount { get => taxAmount; set => taxAmount = value; }
        internal Product PurchasedProduct { get => purchasedProduct; set => purchasedProduct = value; }

        public PriceCalculator()
        {

        }


        public PriceCalculator(double tax, Discount discount, Product product, Expenses expenses)
        {
            PurchasedProduct = product;
            _taxRate = tax;
            this._discount = discount;
            FinalPrice = this.PurchasedProduct.Price;
            _expenses = expenses;

        }

        public double CalculateTax(double price)
        {
            return TaxAmount = FinalPrice * _taxRate;
        }

        public double CalculateUniversalDiscount(double price)

        {
            return price * _discount.UniversalAmount;
        }

        public double CalculateUpcDiscount(double price)
        {
            return price * _discount.UpcAmount;
        }

        public double CalculateTransportExpenses()
        {
            if (_expenses.CalculateTransportCost() == _expenses.TransportCost)
                return  _expenses.TransportCost;
            else
                return PurchasedProduct.Price * _expenses.TransportRate;
        }

        public double CalculatePackagingExpenses()
        {
            if (_expenses.CalculatePackagingCost() == _expenses.PackagingCost)
                return  _expenses.PackagingCost;
            else
                return  PurchasedProduct.Price * _expenses.PackagingRate;
        }

        public double CalculateAdministrativeExpenses()
        {
            if (_expenses.CalculateAdministrativeCost() == _expenses.AdministrativeCost)
                return _expenses.AdministrativeCost;
            else
                return  PurchasedProduct.Price * _expenses.AdministrativeRate;
        }
        public double CalculateCap()
        {
            if (_discount.CalculateCap() == _discount.CapValue)
                return _discount.CapValue;
            else
                return PurchasedProduct.Price * _discount.CapRate;
        }

        public double CalculateAdditiveFinalPrice()
        {
            if (_discount.UpcDiscountbeforeTax == true)
                __deducedPriceFromUPCDiscount = CalculateUpcDiscount(PurchasedProduct.Price);

            if (_discount.UniversalDiscountbeforeTax == true)
                _deducedPriceFromUniversalDiscount = CalculateUniversalDiscount(PurchasedProduct.Price);

            double deducedPriceAmountBeforeTax = Math.Round((__deducedPriceFromUPCDiscount + _deducedPriceFromUniversalDiscount), 2);
            double cap = CalculateCap();
            if (deducedPriceAmountBeforeTax > cap)
                deducedPriceAmountBeforeTax = cap;

            FinalPrice += CalculateTax(PurchasedProduct.Price - _deducedPriceFromUniversalDiscount - __deducedPriceFromUPCDiscount);

            if (_discount.UpcDiscountbeforeTax == false)
                __deducedPriceFromUPCDiscount = CalculateUpcDiscount(PurchasedProduct.Price - deducedPriceAmountBeforeTax);

            if (_discount.UniversalDiscountbeforeTax == false)
                _deducedPriceFromUniversalDiscount = CalculateUniversalDiscount(PurchasedProduct.Price - deducedPriceAmountBeforeTax);

            FinalPrice += CalculatePackagingExpenses() + CalculateTransportExpenses() + CalculateAdministrativeExpenses();
            deducedPriceAmount = Math.Round((__deducedPriceFromUPCDiscount + _deducedPriceFromUniversalDiscount), 2);
            if (deducedPriceAmount > cap)
                deducedPriceAmount = cap;
            FinalPrice -= deducedPriceAmount;
            FinalPrice = Math.Round(FinalPrice, 2);
            return FinalPrice;
        }

        public double CalculateMultiplicativeFinalPrice()
        {
            if (_discount.UpcDiscountbeforeTax == true)
                __deducedPriceFromUPCDiscount = CalculateUpcDiscount(PurchasedProduct.Price);
            
            if (_discount.UniversalDiscountbeforeTax == true)
                _deducedPriceFromUniversalDiscount = CalculateUniversalDiscount(PurchasedProduct.Price - __deducedPriceFromUPCDiscount);

            double deducedPriceAmountBeforeTax = Math.Round((__deducedPriceFromUPCDiscount + _deducedPriceFromUniversalDiscount), 2);
            double cap = CalculateCap();
            if (deducedPriceAmountBeforeTax > cap)
                deducedPriceAmountBeforeTax = cap;

            FinalPrice += CalculateTax(deducedPriceAmountBeforeTax);

            if (_discount.UpcDiscountbeforeTax == false)
                __deducedPriceFromUPCDiscount = CalculateUpcDiscount(PurchasedProduct.Price - _deducedPriceFromUniversalDiscount);

            if (_discount.UniversalDiscountbeforeTax == false)
                _deducedPriceFromUniversalDiscount = CalculateUniversalDiscount(PurchasedProduct.Price - __deducedPriceFromUPCDiscount);


            FinalPrice += CalculatePackagingExpenses() + CalculateTransportExpenses() + CalculateAdministrativeExpenses();
            deducedPriceAmount = Math.Round((__deducedPriceFromUPCDiscount + _deducedPriceFromUniversalDiscount), 2);

            if (deducedPriceAmount > cap)
                deducedPriceAmount = cap;

            FinalPrice -= deducedPriceAmount;
            FinalPrice = Math.Round(FinalPrice, 2);
            return FinalPrice;
        }
    }
}
