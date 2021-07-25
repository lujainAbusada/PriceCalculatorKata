﻿using System;

namespace PriceCalculatorKata
{
   internal class Tax
    {
        private readonly double _taxRate;
        private double _taxAmount;

        public double TaxAmount { get => _taxAmount; }

        public Tax(double taxRate)
        {
            _taxRate = taxRate;
        }

        public double CalculateTax(double price)
        {
            return Math.Round(_taxAmount = price * _taxRate, 4);
        }
    }
}
