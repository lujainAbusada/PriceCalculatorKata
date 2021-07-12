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
            var PriceCalculator = new PriceCalculator(tax,discount,Book);
            PriceCalculator.CalculateFinalPrice();
            new PurchaseReport(PriceCalculator).PrintReport();
        }
    }
}
