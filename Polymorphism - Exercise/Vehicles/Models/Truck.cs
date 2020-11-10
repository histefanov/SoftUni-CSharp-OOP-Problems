using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;

namespace Vehicles.Models
{

    public class Truck : Vehicle
    {
        private const double AIR_CON_CONSUMPTION = 1.6;
        private const double TANK_DAMAGE_FUEL_LOSS = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        { }

        protected override double GetFuelNeeded(double distance)
        {
            return distance * (this.FuelConsumption + AIR_CON_CONSUMPTION);
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity -= liters * TANK_DAMAGE_FUEL_LOSS;
        }
    }
}
