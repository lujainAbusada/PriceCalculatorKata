using System;

namespace PriceCalculatorKata
{
    internal class Expenses
    {
        private readonly string _transportCost;
        private readonly string _packagingCost;
        private readonly string _administrativeCost;
        private const string _percentage = "%";


        public Expenses(string transportCost, string packagingCost, string administrativeCost)
        {
            _transportCost = transportCost;
            _packagingCost = packagingCost;
            _administrativeCost = administrativeCost;
        }

        private double CalculateExpenseValue(double purchasedProductPrice, string expense)
        {
            return expense.Contains(_percentage) ? purchasedProductPrice * Double.Parse(expense.Replace(_percentage, "")) / 100 : Double.Parse(expense);
        }

        public double CalculateTotalExpenses(double purchasedProductPrice)
        {
            return Math.Round(CalculateTransportCost(purchasedProductPrice) +
                CalculatePackagingCost(purchasedProductPrice) +
                CalculateAdministrativeCost(purchasedProductPrice), 4);
        }

        public double CalculateAdministrativeCost(double purchasedProductPrice)
        {
            return CalculateExpenseValue(purchasedProductPrice, _administrativeCost);
        }

        public double CalculatePackagingCost(double purchasedProductPrice)
        {
            return CalculateExpenseValue(purchasedProductPrice, _packagingCost);
        }

        public double CalculateTransportCost(double purchasedProductPrice)
        {
            return CalculateExpenseValue(purchasedProductPrice, _transportCost);
        }
    }
}
