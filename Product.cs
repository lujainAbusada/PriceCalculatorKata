using System;

namespace PriceCalculatorKata
{
    class Product
    {
        private readonly string _name;
        private readonly int _upc;
        private readonly double _price;
        private readonly double _upcDiscount;

        public double Price { get => _price; }
        public double UpcDiscount { get => _upcDiscount; }
        public int Upc { get => _upc; }
        public string Name { get => _name; }

        public Product(string name, int UPC, double price, double UpcDiscount)
        {
            _name = name;
            _upc = UPC;
            _price = price;
            _upcDiscount = UpcDiscount;
        }
    }
}
