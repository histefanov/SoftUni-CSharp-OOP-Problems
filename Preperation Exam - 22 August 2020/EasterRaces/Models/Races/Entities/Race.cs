using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string _name;
        private int _laps;
        private ICollection<IDriver> _drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            _drivers = new List<IDriver>();
        }

        public string Name
        {
            get => _name;
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

        public int Laps
        {
            get => _laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(
                        String.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                _laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => (IReadOnlyCollection<IDriver>)_drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(
                    String.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (_drivers.Any(x => x.Name == driver.Name))
            {
                throw new ArgumentNullException(
                    String.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, Name));
            }

            _drivers.Add(driver);
        }
    }
}
