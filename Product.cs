using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Product
    {

        private string _name;
        private int _upc;
        private double price;
        private double upcDiscount;

        public double Price { get => price; set => price = value; }
        public double UpcDiscount { get => upcDiscount; set => upcDiscount = value; }

        public Product()
        { }

        public Product(string name, int UPC, double price, double UpcDiscount)
        {
            this._name = name;
            this._upc = UPC;
            this.price = price;
            this.upcDiscount = UpcDiscount;

        }
    }
}
