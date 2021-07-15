using System;

namespace PriceCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Product Book = new Product("The Little Prince Book", 12345, 20.25, 0);
            Console.WriteLine("Please Enter Tax amount:");
            Double tax = Double.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter Universal Discount amount:");
            Double Universaldiscount = Double.Parse(Console.ReadLine());
            Console.WriteLine("Is Universal Discount applied before tax?");
            bool universalBeforeTax = Boolean.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter UPC Discount amount:");
            Double upcdiscount = Double.Parse(Console.ReadLine());
            Console.WriteLine("Is Universal Discount applied before tax?");
            bool upcBeforeTax = Boolean.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter Transport cost:");
            String Transport = Console.ReadLine();
            Console.WriteLine("Please Enter Packaging Cost:");
            string packaging = Console.ReadLine();
            Console.WriteLine("Please Enter administartive expenses Cost:");
            string administrative = Console.ReadLine();
            var PriceCalculator = new PriceCalculator(tax, new Discount(Universaldiscount, universalBeforeTax, upcdiscount, upcBeforeTax), Book, new Expenses(Transport, packaging, administrative));
            Console.WriteLine("Is discount Additive or Multiplative?");
            if (Console.ReadLine().ToLower() == "additive")
                PriceCalculator.CalculateAdditiveFinalPrice();
            else
                PriceCalculator.CalculateMultiplativeFinalPrice();
            new PurchaseReport(PriceCalculator).PrintReport();
        }
    }
}
