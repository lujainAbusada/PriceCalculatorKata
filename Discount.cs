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
        private double capValue;
        private double capRate;
        private string capString;


        public Discount()
        {

        }

        public Discount(double universalAmount, bool universalDiscountbeforeTax, double upcAmount, bool upcDiscountbeforeTax, string capString)
        {
            this.universalAmount = universalAmount;
            this.UniversalDiscountbeforeTax = universalDiscountbeforeTax;
            this.UpcAmount = upcAmount;
            this.UpcDiscountbeforeTax = upcDiscountbeforeTax;
            this.capString = capString;
        }

        public double UniversalAmount { get => universalAmount; set => universalAmount = value; }
        public bool UniversalDiscountbeforeTax { get => universalDiscountbeforeTax; set => universalDiscountbeforeTax = value; }
        public double UpcAmount { get => upcAmount; set => upcAmount = value; }
        public bool UpcDiscountbeforeTax { get => upcDiscountbeforeTax; set => upcDiscountbeforeTax = value; }
        public double CapRate { get => capRate; set => capRate = value; }
        public double CapValue { get => capValue; set => capValue = value; }

        public double CalculateCap()
        {
            if (capString.Contains('%'))
            {
                capString = capString.Replace("%", "");
                capRate = Double.Parse(capString) / 100;

                return capRate / 100;

            }
            else
            {
                capString = capString.Replace("$", "");
                capValue = Double.Parse(capString);
                return capValue;
            }
        }
    }
}
