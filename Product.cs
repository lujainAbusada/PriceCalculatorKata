using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Product
    {

        private string name;
        private int upc;
        private double price;
        private double upcDiscount;

        public string Name { get => name; set => name = value; }
        public int Upc { get => upc; set => upc = value; }
        public double Price { get => price; set => price = value; }
        public double UpcDiscount { get => upcDiscount; set => upcDiscount = value; }

        public Product()
        { }

        public Product(string name, int UPC, double price, double UpcDiscount)
        {
            this.name = name;
            this.upc = UPC;
            this.price = price;
            this.upcDiscount = UpcDiscount;

        }
    }
}
