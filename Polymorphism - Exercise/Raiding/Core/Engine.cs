using Raiding.Common;
using Raiding.Factories;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Core
{
    public class Engine
    {
        public Engine()
        { }

        public void Run()
        {
            ICollection<BaseHero> raidGroup = new List<BaseHero>();
            int raidGroupCount = int.Parse(Console.ReadLine());

            while (raidGroup.Count < raidGroupCount)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    BaseHero hero = HeroFactory.CreateHero(heroType, heroName);
                    raidGroup.Add(hero);
                }
                catch (InvalidHeroTypeException exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int raidGroupPower = 0;

            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                raidGroupPower += hero.Power;
            }

            Console.WriteLine(raidGroupPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
