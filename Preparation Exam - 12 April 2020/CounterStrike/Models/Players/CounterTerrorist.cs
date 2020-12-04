using System;
using System.Collections.Generic;
using System.Text;

using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Players
{
    public class CounterTerrorist : Player, IPlayer
    {
        public CounterTerrorist(string username, int health, int armor, IGun gun)
            : base(username, health, armor, gun)
        {

        }
    }
}
