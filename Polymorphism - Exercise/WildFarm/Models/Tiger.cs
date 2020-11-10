using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        private const string TIGER_SOUND = "ROAR!!!";
        private const double WEIGHT_GAIN = 1.0;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.AcceptableFoods = new HashSet<string> { "Meat" };
        }

        public override ICollection<string> AcceptableFoods { get; set; }

        public override string AskForFood()
        {
            return TIGER_SOUND;
        }

        public override void Eat(Food food)
        {
            base.Eat(food);
            this.Weight += WEIGHT_GAIN * food.Quantity;
        }
    }
}
