using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value == "")
                {
                    throw new Exception("A name should not be empty.");
                }
                this.name = value;
            }
        }
        public int Rating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return (int)Math.Round(this.players.Select(p => p.Overall).Sum() * 1.0 / this.players.Count);
                }
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {          
            if (!players.Exists(p => p.Name == playerName))
            {
                throw new Exception($"Player {playerName} is not in {this.Name} team.");
            }
            else
            {
                var player = players.FirstOrDefault(p => p.Name == playerName);
                players.Remove(player);
            }
        }
    }
}
