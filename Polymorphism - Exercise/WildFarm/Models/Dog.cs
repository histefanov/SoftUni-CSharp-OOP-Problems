using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        private const string DOG_SOUND = "Woof!";
        private const double WEIGHT_GAIN = 0.4;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.AcceptableFoods = new HashSet<string> { "Meat" };
        }

        public override ICollection<string> AcceptableFoods { get; set; }

        public override string AskForFood()
        {
            return DOG_SOUND;
        }

        public override void Eat(Food food)
        {
            base.Eat(food);
            this.Weight += WEIGHT_GAIN * food.Quantity;
        }
    }
}
