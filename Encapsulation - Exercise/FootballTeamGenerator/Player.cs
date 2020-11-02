using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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
        public int Endurance 
        {
            get => this.endurance;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Endurance should be between 0 and 100.");
                }
                this.endurance = value;
            }
        }
        public int Sprint 
        {
            get => this.sprint;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Sprint should be between 0 and 100.");
                }
                this.sprint = value;
            }
        }
        public int Dribble 
        {
            get => this.dribble;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Dribble should be between 0 and 100.");
                }
                this.dribble = value;
            }
        }
        public int Passing 
        {
            get => this.passing;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Passing should be between 0 and 100.");
                }
                this.passing = value;
            }
        }
        public int Shooting 
        {
            get => this.shooting;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Shooting should be between 0 and 100.");
                }
                this.shooting = value;
            }
        }
        public int Overall { get
                => (int)Math.Round((this.endurance + this.sprint + this.dribble + this.passing + this.shooting) * 1.0 / 5); }      
    }
}
