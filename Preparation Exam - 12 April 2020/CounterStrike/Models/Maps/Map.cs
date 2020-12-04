using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    class Map : IMap
    {
        private ICollection<IPlayer> _terrorists;
        private ICollection<IPlayer> _counterTerrorists;

        public Map()
        {
            _terrorists = new List<IPlayer>();
            _counterTerrorists = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            GenerateTeams(players);
            string result = Fight();
            return result;
        }


        private void GenerateTeams(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is Terrorist)
                {
                    _terrorists.Add(player);
                }
                else
                {
                    _counterTerrorists.Add(player);
                }
            }
        }

        private string Fight()
        {
            string battleResult = string.Empty;

            while (true)
            {
                Attack(_terrorists, _counterTerrorists);
                Attack(_counterTerrorists, _terrorists);

                if (!AreAlive(_counterTerrorists))
                {
                    battleResult = "Terrorist wins!";
                    break;
                }

                if (!AreAlive(_terrorists))
                {
                    battleResult = "Counter Terrorist wins!";
                    break;
                }
            }

            return battleResult;
        }

        private bool AreAlive(ICollection<IPlayer> players)
        {
            return players.Any(p => p.IsAlive);
        }

        private void Attack(ICollection<IPlayer> attackers, ICollection<IPlayer> receivers)
        {
            foreach (var att in attackers)
            {
                foreach (var rec in receivers)
                {
                    rec.TakeDamage(att.Gun.Fire());
                }
            }
        }
    }
}
