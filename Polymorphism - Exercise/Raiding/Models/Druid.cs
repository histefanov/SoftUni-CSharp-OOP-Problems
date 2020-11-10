using Raiding.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DEFAULT_DRUID_POWER = 80;

        public Druid(string name)
            : base(name)
        {
            this.Power = DEFAULT_DRUID_POWER;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
