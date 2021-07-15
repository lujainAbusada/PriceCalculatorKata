using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{

    class PriceCalculator
    {
        private double _taxAmount;
        private Product _purchasedProduct;
        private Discount _discount;
        private Expenses _expenses;
        private double __deducedPriceFromUPCDiscount = 0;
        private double _deducedPriceFromUniversalDiscount = 0;
        private double deducedPriceAmount = 0;
        private double finalPrice;

        public double FinalPrice { get => finalPrice; set => finalPrice = value; }
        public double DeducedPriceAmount { get => deducedPriceAmount; set => deducedPriceAmount = value; }

        public PriceCalculator()
        {

        }


        public PriceCalculator(double tax, Discount discount, Product product, Expenses expenses)
        {
            _purchasedProduct = product;
            _taxAmount = tax;
            this._discount = discount;
            FinalPrice = this._purchasedProduct.Price;
            _expenses = expenses;

        }

        public double CalculateTax(double price)
        {
            return FinalPrice * _taxAmount;
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
                return _purchasedProduct.Price * _expenses.TransportRate;
        }

        public double CalculatePackagingExpenses()
        {
            if (_expenses.CalculatePackagingCost() == _expenses.PackagingCost)
                return  _expenses.PackagingCost;
            else
                return  _purchasedProduct.Price * _expenses.PackagingRate;
        }

        public double CalculateAdministrativeExpenses()
        {
            if (_expenses.CalculateAdministrativeCost() == _expenses.AdministrativeCost)
                return _expenses.AdministrativeCost;
            else
                return  _purchasedProduct.Price * _expenses.AdministrativeRate;
        }
        public double CalculateCap()
        {
            if (_discount.CalculateCap() == _discount.CapValue)
                return _discount.CapValue;
            else
                return _purchasedProduct.Price * _discount.CapRate;
        }

        public double CalculateAdditiveFinalPrice()
        {
            if (_discount.UpcDiscountbeforeTax == true)
                __deducedPriceFromUPCDiscount = CalculateUpcDiscount(_purchasedProduct.Price);

            if (_discount.UniversalDiscountbeforeTax == true)
                _deducedPriceFromUniversalDiscount = CalculateUniversalDiscount(_purchasedProduct.Price);

            double deducedPriceAmountBeforeTax = Math.Round((__deducedPriceFromUPCDiscount + _deducedPriceFromUniversalDiscount), 2);
            double cap = CalculateCap();
            if (deducedPriceAmountBeforeTax > cap)
                deducedPriceAmountBeforeTax = cap;

            FinalPrice += CalculateTax(_purchasedProduct.Price - _deducedPriceFromUniversalDiscount - __deducedPriceFromUPCDiscount);

            if (_discount.UpcDiscountbeforeTax == false)
                __deducedPriceFromUPCDiscount = CalculateUpcDiscount(_purchasedProduct.Price - deducedPriceAmountBeforeTax);

            if (_discount.UniversalDiscountbeforeTax == false)
                _deducedPriceFromUniversalDiscount = CalculateUniversalDiscount(_purchasedProduct.Price - deducedPriceAmountBeforeTax);

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
                __deducedPriceFromUPCDiscount = CalculateUpcDiscount(_purchasedProduct.Price);
            
            if (_discount.UniversalDiscountbeforeTax == true)
                _deducedPriceFromUniversalDiscount = CalculateUniversalDiscount(_purchasedProduct.Price - __deducedPriceFromUPCDiscount);

            double deducedPriceAmountBeforeTax = Math.Round((__deducedPriceFromUPCDiscount + _deducedPriceFromUniversalDiscount), 2);
            double cap = CalculateCap();
            if (deducedPriceAmountBeforeTax > cap)
                deducedPriceAmountBeforeTax = cap;

            FinalPrice += CalculateTax(deducedPriceAmountBeforeTax);

            if (_discount.UpcDiscountbeforeTax == false)
                __deducedPriceFromUPCDiscount = CalculateUpcDiscount(_purchasedProduct.Price - _deducedPriceFromUniversalDiscount);

            if (_discount.UniversalDiscountbeforeTax == false)
                _deducedPriceFromUniversalDiscount = CalculateUniversalDiscount(_purchasedProduct.Price - __deducedPriceFromUPCDiscount);


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
