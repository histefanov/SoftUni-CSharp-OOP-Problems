using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string _username;
        private int _health;
        private int _armor;
        private IGun _gun;

        public Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }

        public string Username
        {
            get
            {
                return _username;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                _username = value;
            }
        }

        public int Health
        {
            get
            {
                return _health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                _health = value;
            }
        }

        public int Armor
        {
            get
            {
                return _armor;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                _armor = value;
            }
        }

        public IGun Gun
        {
            get
            {
                return _gun;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                _gun = value;
            }
        }

        public bool IsAlive => Health > 0;

        public void TakeDamage(int points)
        {
            int damage = points;
            damage = ReduceDamageThroughArmor(damage);

            if (Health >= damage)
            {
                Health -= damage;
            }
            else
            {
                Health = 0;
            }        
        }

        private int ReduceDamageThroughArmor(int damage)
        {
            if (Armor > 0)
            {
                if (damage > Armor)
                {
                    damage -= Armor;
                    Armor = 0;
                }
                else
                {
                    Armor -= damage;
                    damage = 0;
                }
            }
            return damage;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"{this.GetType().Name}: {Username}")
                .AppendLine($"--Health: {Health}")
                .AppendLine($"--Armor: {Armor}")
                .Append($"--Gun: {Gun.Name}");

            return sb.ToString();
        }
    }
}
