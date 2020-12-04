using System;
using System.Collections.Generic;
using System.Text;

using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun, IGun
    {
        private const int FIRE_RATE = 1;

        public Pistol(string name, int bulletsCount)
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
