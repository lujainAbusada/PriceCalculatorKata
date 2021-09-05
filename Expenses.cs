using System;

namespace PriceCalculatorKata
{
    internal class Expenses
    {
        private readonly string _transportCostString;
        private readonly string _packagingCostString;
        private readonly string _administrativeCostString;
        private double _transportCost;
        private double _packagingCost;
        private double _administrativeCost;
        private const string _percentage = "%";

        public double TransportCost { get => _transportCost;  }
        public double PackagingCost { get => _packagingCost; }
        public double AdministrativeCost { get => _administrativeCost; }

        public Expenses(string transportCostString, string packagingCostString, string administrativeCostString)
        {
            _transportCostString = transportCostString;
            _packagingCostString = packagingCostString;
            _administrativeCostString = administrativeCostString;
        }

        public double CalculateExpenseValue(double purchasedProductPrice, string expenseString)
        {
            return expenseString.Contains(_percentage) ? purchasedProductPrice * Double.Parse(expenseString.Replace(_percentage, "")) / 100 : Double.Parse(expenseString);
        }

        public double CalculateTotalExpenses(double purchasedProductPrice)
        {
            _transportCost = CalculateExpenseValue(purchasedProductPrice, _transportCostString);
            _packagingCost = CalculateExpenseValue(purchasedProductPrice, _packagingCostString);
            _administrativeCost = CalculateExpenseValue(purchasedProductPrice, _administrativeCostString);
            return Math.Round(_packagingCost+_transportCost+_administrativeCost, 4);
        }
    }
}
