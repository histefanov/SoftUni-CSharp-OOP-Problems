using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core.Contracts
{
    public class Controller : IController
    {
        private IRepository<IGun> _guns;
        private IRepository<IPlayer> _players;
        private IMap _map;

        public Controller()
        {
            _guns = new GunRepository();
            _players = new PlayerRepository();
            _map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = type switch
            {
                "Pistol" => new Pistol(name, bulletsCount),
                "Rifle" => new Rifle(name, bulletsCount),
                _ => throw new ArgumentException(ExceptionMessages.InvalidGunType)
            };

            _guns.Add(gun);
            var result = String.Format(OutputMessages.SuccessfullyAddedGun, name);
            return result;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = _guns.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = type switch
            {
                "Terrorist" => new Terrorist(username, health, armor, gun),
                "CounterTerrorist" => new CounterTerrorist(username, health, armor, gun),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPlayerType)
            };

            _players.Add(player);
            var result = String.Format(OutputMessages.SuccessfullyAddedPlayer, username);
            return result;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            var sorted = _players.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username);

            foreach (var player in sorted)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            return _map.Start(_players.Models as ICollection<IPlayer>);
        }
    }
}
