using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterTank
{
    class WaterTank
    {
        // FIELDS
        // single instance Field: amount -> gals H2O in the tank
        private double amount = 0;
        private static double pricePerGallon = 1.0;

        // CONSTRUCTORS
        public WaterTank(double amount) {
            this.amount = amount;
        }

        // PROPERTIES -- accessors, getter/setters
        public double Amount { get { return this.amount; } set { amount = value; } }
        public static double PricePerGallon { get { return pricePerGallon; } }

        // Instance METHODS
        // add water
        public void AddWater(double amountToAdd)
        {
            this.amount += amountToAdd;
        }

        // use water
        public void UseWater(double amountUsed)
        {
            if (amountUsed < this.amount)
                this.amount -= amountUsed;
        }

        // static add (two tanks' amount together)
        public static WaterTank Combine(WaterTank tank1, WaterTank tank2)
        {
            WaterTank tank = new WaterTank(tank1.Amount + tank2.Amount);
            return tank;
        }
    }
}
