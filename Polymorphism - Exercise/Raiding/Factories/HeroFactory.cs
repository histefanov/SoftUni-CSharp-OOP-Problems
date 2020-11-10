using Raiding.Common;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public static class HeroFactory
    {
        public static BaseHero CreateHero(string heroType, string heroName)
        {
            return heroType switch
            {
                "Druid" => new Druid(heroName),
                "Paladin" => new Paladin(heroName),
                "Rogue" => new Rogue(heroName),
                "Warrior" => new Warrior(heroName),
                _ => throw new InvalidHeroTypeException(ExceptionMessages.INVALID_HERO_MESSAGE),
            };
        }
    }
}
