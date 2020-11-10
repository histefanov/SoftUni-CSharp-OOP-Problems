using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CON_CONSUMPTION = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        { }

        protected override double GetFuelNeeded(double distance)
        {
            return distance * (this.FuelConsumption + AIR_CON_CONSUMPTION);
        }

        private double GetFuelNeededEmpty(double distance)
        {
            return distance * this.FuelConsumption;
        }

        public string DriveEmpty(double distance)
        {
            double fuelNeeded = this.GetFuelNeededEmpty(distance);

            if (fuelNeeded > this.FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }
    }
}
