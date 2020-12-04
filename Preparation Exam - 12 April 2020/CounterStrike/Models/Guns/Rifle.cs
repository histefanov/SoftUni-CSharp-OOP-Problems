using System;
using System.Collections.Generic;
using System.Text;

using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun, IGun
    {
        private const int FIRE_RATE = 10;

        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {

        }

        public override int Fire()
        {
            var bulletsFired = 0;

            if (BulletsCount >= FIRE_RATE)
            {
                bulletsFired = FIRE_RATE;
                BulletsCount -= bulletsFired;
            }

            return bulletsFired;
        }
    }
}
