using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        private const string CAT_SOUND = "Meow";
        private const double WEIGHT_GAIN = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.AcceptableFoods = new HashSet<string> { "Vegetable", "Meat" };
        }

        public override ICollection<string> AcceptableFoods { get; set; }

        public override string AskForFood()
        {
            return CAT_SOUND;
        }

        public override void Eat(Food food)
        {
            base.Eat(food);
            this.Weight += WEIGHT_GAIN * food.Quantity;
        }
    }
}
