using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Product
    {
        internal string Name { get; set; }
        internal int UPC { get; set; }
        internal double Price { get; set; }
        internal double UPCDiscount { get; set; }


        public Product()
        { }

        public Product(string name, int UPC, double price, double UPCDiscount)
        {
            this.Name = name;
            this.UPC = UPC;
            this.Price = price;
            this.UPCDiscount = UPCDiscount;

        }
    }
}
