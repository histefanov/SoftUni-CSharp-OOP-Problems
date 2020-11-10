using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        public Engine()
        { }

        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            IVehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string cmd = input[0];
                string vehicleType = input[1];
                double value = double.Parse(input[2]);

                try
                {
                    switch (vehicleType)
                    {
                        case "Car":
                            if (cmd == "Drive")
                            {
                                Console.WriteLine(car.Drive(value));
                            }
                            else
                            {
                                car.Refuel(value);
                            }
                            break;

                        case "Truck":
                            if (cmd == "Drive")
                            {
                                Console.WriteLine(truck.Drive(value));
                            }
                            else
                            {
                                truck.Refuel(value);
                            }
                            break;

                        case "Bus":
                            if (cmd == "Drive")
                            {
                                Console.WriteLine(bus.Drive(value));
                            }
                            else if (cmd == "DriveEmpty")
                            {
                                Console.WriteLine((bus as Bus).DriveEmpty(value));
                            }
                            else
                            {
                                bus.Refuel(value);
                            }
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car + Environment.NewLine + truck + Environment.NewLine + bus);
        }
    }
}
