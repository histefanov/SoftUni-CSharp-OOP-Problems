using System;
using System.Collections.Generic;
using System.Text;

using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string _name;
        private int _bulletsCount;

        public Gun(string name, int bulletsCount)
        {
            Name = name;
            BulletsCount = bulletsCount;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                _name = value;
            }
        }

        public int BulletsCount
        {
            get
            {
                return _bulletsCount;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }
                _bulletsCount = value;
            }
        }

        public abstract int Fire();
    }
}
