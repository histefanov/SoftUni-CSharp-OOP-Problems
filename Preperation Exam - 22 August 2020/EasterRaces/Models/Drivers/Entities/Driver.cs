using System;
using System.Collections.Generic;
using System.Text;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string _name;
        private ICar _car;

        public Driver(string name)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(
                        String.Format(ExceptionMessages.InvalidName, value, 5));
                }
                _name = value;
            }
        }

        public ICar Car
        {
            get => _car;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.CarInvalid);
                }
                _car = value;
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => Car != null;

        public void AddCar(ICar car)
        {
            Car = car;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
