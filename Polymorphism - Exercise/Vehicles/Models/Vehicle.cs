using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const string INVALID_FUEL_AMOUNT = "Cannot fit {0} fuel in the tank";
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        protected abstract double GetFuelNeeded(double distance);

        public string Drive(double distance)
        {
            double fuelNeeded = this.GetFuelNeeded(distance);

            if (fuelNeeded > this.FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (liters + this.FuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException(String.Format(INVALID_FUEL_AMOUNT, liters));
            }
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
