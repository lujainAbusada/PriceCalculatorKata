using System;

namespace PriceCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Product Book = new Product("The Little Prince Book", 12345, 20.25, 0.07);
            Console.WriteLine("Please Enter Tax amount:");
            Double tax = Double.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter Discount amount:");
            Double discount = Double.Parse(Console.ReadLine());
            PriceCalculator price = new PriceCalculator(tax,discount,Book);
            Console.WriteLine($"The original price is {Book.Price}");
            Console.WriteLine($"The price after tax is {price.FinalPrice()}");
        }
    }
}
