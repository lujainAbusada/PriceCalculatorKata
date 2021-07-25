using System;

namespace PriceCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Product Book = new Product("The Little Prince Book", 12345, 20.25, 0);
            Console.WriteLine("Please Enter Tax amount:");
            Tax tax = new Tax(Double.Parse(Console.ReadLine()));
            Console.WriteLine("Please Enter Universal Discount amount:");
            Double Universaldiscount = Double.Parse(Console.ReadLine());
            Console.WriteLine("Is Universal Discount applied before tax?");
            bool universalBeforeTax = Boolean.Parse(Console.ReadLine());
            UniversalDiscount universal = new UniversalDiscount(Universaldiscount, universalBeforeTax);
            Console.WriteLine("Please Enter UPC Discount amount:");
            Double upcdiscount = Double.Parse(Console.ReadLine());
            Console.WriteLine("Is Upc Discount applied before tax?");
            bool upcBeforeTax = Boolean.Parse(Console.ReadLine());
            UpcDiscount upc = new UpcDiscount(upcdiscount, upcBeforeTax);
            Console.WriteLine("Please Enter Transport cost:");
            String Transport = Console.ReadLine();
            Console.WriteLine("Please Enter Packaging Cost:");
            string packaging = Console.ReadLine();
            Console.WriteLine("Please Enter administartive expenses Cost:");
            string administrative = Console.ReadLine();
            Expenses expenses = new Expenses(Transport, packaging, administrative);
            Console.WriteLine("Please Enter Discount cap:");
            Cap cap = new Cap(Console.ReadLine());
            Console.WriteLine("Please specify the currency:");
            Currency currency = new Currency(Console.ReadLine());
            Console.WriteLine("Is Discount additive or multiplicative?");
            IDiscountCalculator discountCalculator;
            if (Console.ReadLine().ToLower() == "additive")
               discountCalculator = new AdditiveDiscountCalculator(upc, universal);
            else
           
            discountCalculator = new MultiplicativeDiscountCalculator(upc, universal);

            PriceCalculator priceCalculator = new PriceCalculator(Book, tax, discountCalculator, expenses, currency, cap);
            priceCalculator.CalculateFinalPrice();
            new PurchaseReport(priceCalculator).PrintReport();
        }
    }
}
