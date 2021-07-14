using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Expenses
    {
        private double packagingCost;
        private double transportCost;
        private double packagingRate;
        private double transportRate;
        private double administrativeCost;
        private double administrativeRate;
        private string transportCostString;
        private string packagingCostString;
        private string administrativeCostString;


        public double PackagingCost { get => packagingCost; set => packagingCost = value; }
        public double TransportCost { get => transportCost; set => transportCost = value; }
        public double PackagingRate { get => packagingRate; set => packagingRate = value; }
        public double TransportRate { get => transportRate; set => transportRate = value; }
        public double AdministrativeCost { get => administrativeCost; set => administrativeCost = value; }
        public double AdministrativeRate { get => administrativeRate; set => administrativeRate = value; }

        public Expenses()
        {

        }

        public Expenses(string transportCostString, string packagingCostString, string administrativeCostString)
        {
            this.transportCostString = transportCostString;
            this.packagingCostString = packagingCostString;
            this.administrativeCostString = administrativeCostString;
        }

        public double CalculatePackagingCost()
        {
            if (packagingCostString.Contains('%'))
            {
                packagingCostString = packagingCostString.Replace("%", "");
                packagingRate = Double.Parse(packagingCostString) / 100;
                return PackagingRate / 100;

            }
            else
            {
                packagingCostString = packagingCostString.Replace("$", "");
                packagingCost = Double.Parse(packagingCostString);
                return PackagingCost;
            }


        }

        public double CalculateTransportCost()
        {
            if (transportCostString.Contains('%'))
            {
                transportCostString = transportCostString.Replace("%", "");
                transportRate = Double.Parse(transportCostString) / 100;

                return transportRate / 100;

            }
            else
            {
                transportCostString = transportCostString.Replace("$", "");
                transportCost = Double.Parse(transportCostString);
                return transportCost;
            }
        }

        public double CalculateAdministrativeCost()
        {
            if (administrativeCostString.Contains('%'))
            {
                administrativeCostString = administrativeCostString.Replace("%", "");
                administrativeRate = Double.Parse(administrativeCostString) / 100;

                return administrativeRate / 100;

            }
            else
            {
                administrativeCostString = administrativeCostString.Replace("$", "");
                administrativeCost = Double.Parse(administrativeCostString);
                return administrativeCost;
            }
        }
    }
}
