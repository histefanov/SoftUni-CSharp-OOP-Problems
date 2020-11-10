using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Contracts
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
        public double TankCapacity { get; }

        public string Drive(double distance);
        public void Refuel(double liters);
    }
}
