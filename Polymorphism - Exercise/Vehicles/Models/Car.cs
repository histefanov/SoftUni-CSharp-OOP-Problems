using System;
using System.Collections.Generic;
using System.Text;

using Vehicles.Contracts;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AIR_CON_CONSUMPTION = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        { }

        protected override double GetFuelNeeded(double distance)
        {
            return distance * (this.FuelConsumption + AIR_CON_CONSUMPTION);
        }
    }
}
