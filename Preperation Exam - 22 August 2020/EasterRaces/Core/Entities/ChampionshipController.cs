using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IDriver> _driverRepository;
        private IRepository<ICar> _carRepository;
        private IRepository<IRace> _raceRepository;

        public ChampionshipController()
        {
            _driverRepository = new DriverRepository();
            _carRepository = new CarRepository();
            _raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = _driverRepository.GetByName(driverName);
            var car = _carRepository.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (car == null)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            string outputMsg = String.Format(OutputMessages.CarAdded, driverName, carModel);
            return outputMsg;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = _raceRepository.GetByName(raceName);
            var driver = _driverRepository.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            string outputMsg = String.Format(OutputMessages.DriverAdded, driverName, raceName);
            return outputMsg;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (_carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(
                    String.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = type switch
            {
                "Muscle" => new MuscleCar(model, horsePower),
                "Sports" => new SportsCar(model, horsePower),
                _ => throw new ArgumentException("Invalid car type!!!")
            };

            _carRepository.Add(car);

            string outputMsg = String.Format(OutputMessages.CarCreated, type + "Car", model);
            return outputMsg;
        }

        public string CreateDriver(string driverName)
        {
            if (_driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(
                    String.Format(ExceptionMessages.DriversExists, driverName));
            }

            _driverRepository.Add(new Driver(driverName));

            string outputMsg = String.Format(OutputMessages.DriverCreated, driverName);
            return outputMsg;
        }

        public string CreateRace(string name, int laps)
        {
            if (_raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.RaceExists, name));
            }

            _raceRepository.Add(new Race(name, laps));

            string outputMsg = String.Format(OutputMessages.RaceCreated, name);
            return outputMsg;
        }

        public string StartRace(string raceName)
        {
            var race = _raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var fastestDrivers = race.Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .Select(d => d.Name)
                .ToList();

            var sb = new StringBuilder();
            sb
                .AppendLine(
                    String.Format(OutputMessages.DriverFirstPosition, fastestDrivers[0], race.Name))
                .AppendLine(
                    String.Format(OutputMessages.DriverSecondPosition, fastestDrivers[1], race.Name))
                .Append(
                    String.Format(OutputMessages.DriverThirdPosition, fastestDrivers[2], race.Name));

            _raceRepository.Remove(race);

            return sb.ToString();
        }
    }
}
