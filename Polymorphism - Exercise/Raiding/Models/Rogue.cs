using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int DEFAULT_ROGUE_POWER = 80;

        public Rogue(string name) 
            : base(name)
        {
            this.Power = DEFAULT_ROGUE_POWER;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
