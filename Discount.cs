using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Discount
    {
        private double universalAmount;
        private bool universalDiscountbeforeTax;
        private double upcAmount;
        private bool upcDiscountbeforeTax;


        public Discount()
        {

        }

        public Discount(double universalAmount, bool universalDiscountbeforeTax, double upcAmount, bool upcDiscountbeforeTax)
        {
            this.universalAmount = universalAmount;
            this.UniversalDiscountbeforeTax = universalDiscountbeforeTax;
            this.UpcAmount = upcAmount;
            this.UpcDiscountbeforeTax = upcDiscountbeforeTax;
        }

        public double UniversalAmount { get => universalAmount; set => universalAmount = value; }
        public bool UniversalDiscountbeforeTax { get => universalDiscountbeforeTax; set => universalDiscountbeforeTax = value; }
        public double UpcAmount { get => upcAmount; set => upcAmount = value; }
        public bool UpcDiscountbeforeTax { get => upcDiscountbeforeTax; set => upcDiscountbeforeTax = value; }

    }
}
