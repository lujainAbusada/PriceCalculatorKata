using System;

namespace PriceCalculatorKata
{
    internal class Expenses
    {
        private readonly string _transportCostString;
        private readonly string _packagingCostString;
        private readonly string _administrativeCostString;
        private readonly string _percentage = "%";

        public Expenses(string transportCostString, string packagingCostString, string administrativeCostString)
        {
            this._transportCostString = transportCostString;
            this._packagingCostString = packagingCostString;
            this._administrativeCostString = administrativeCostString;
        }

        public double CalculateExpenseValue(double purchasedProductPrice, string expenseString)
        {
            if (expenseString.Contains(_percentage))
            {
                expenseString = expenseString.Replace(_percentage, "");
                return purchasedProductPrice * Double.Parse(expenseString) / 100;
            }
            else
            {
                return Double.Parse(expenseString);
            }
        }

        public double CalculateTotalExpenses(double purchasedProductPrice)
        {
            return Math.Round(CalculateExpenseValue(purchasedProductPrice, _transportCostString) +
                CalculateExpenseValue(purchasedProductPrice, _packagingCostString) +
                CalculateExpenseValue(purchasedProductPrice, _administrativeCostString), 4);
        }
    }
}
