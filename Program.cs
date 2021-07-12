using System;

namespace PriceCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Product Book = new Product("The Little Prince Book", 12345, 20.25, 0.07);
            Console.WriteLine("Please Enter Tax amount:");
            PriceCalculator price = new PriceCalculator(Double.Parse(Console.ReadLine()),Book);
            Console.WriteLine($"The original price is {Book.Price}");
            Console.WriteLine($"The price after tax is {price.TaxCalculator()}");
        }
    }
}
