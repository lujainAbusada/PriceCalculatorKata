﻿using System;

namespace PriceCalculatorKata
{
    class AdditiveDiscountCalculator : IDiscountCalculator
    {
        private UpcDiscount _upc;
        private UniversalDiscount _universal;
        private double _priceBeforeTax;
        private double _deducedAmount;

        public double PriceBeforeDiscount { get => _priceBeforeTax; }

        public AdditiveDiscountCalculator(UpcDiscount upc, UniversalDiscount universal)
        {
            this._upc = upc;
            this._universal = universal;
        }

        public double CalculateTotalDiscount(double price)
        {
            if ((_upc.BeforeTax == true && _universal.BeforeTax == true))
            {
                return CalculateUpcAndUniversalBeforeTax(price);
            }
            else if ((_upc.BeforeTax == false && _universal.BeforeTax == false))
            {
                return CalculateUpcAndUniversalAfterTax(price);
            }
            else if (_upc.BeforeTax == false && _universal.BeforeTax == true)
            {
                return CalculateUpcAfterAndUniversalBeforeTax(price);
            }
            else
            {
                return CalculateUpcBeforeAndUniversalAfterTax(price);
            }
        }

        public double CalculateUpcAndUniversalBeforeTax(double price)
        {
            _deducedAmount = _upc.CalculateDiscount(price) + _universal.CalculateDiscount(price);
            _priceBeforeTax = price - _deducedAmount;
            return _deducedAmount;
        }
        public double CalculateUpcAfterAndUniversalBeforeTax(double price)
        {
            _deducedAmount = _universal.CalculateDiscount(price);
            _priceBeforeTax = price - _deducedAmount;
            return _deducedAmount += _upc.CalculateDiscount(price - _deducedAmount);
        }
        public double CalculateUpcBeforeAndUniversalAfterTax(double price)
        {
            _deducedAmount = _upc.CalculateDiscount(price);
            _priceBeforeTax = price - _deducedAmount;
            return _deducedAmount += _universal.CalculateDiscount(price - _deducedAmount);
        }

        public double CalculateUpcAndUniversalAfterTax(double price)
        {
            _deducedAmount = _upc.CalculateDiscount(price) + _universal.CalculateDiscount(price);
            _priceBeforeTax = price;
            return _deducedAmount;
        }
    }
}