using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Hen : Bird
    {
        private const string HEN_SOUND = "Cluck";
        private const double WEIGHT_GAIN = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.AcceptableFoods = new HashSet<string> { "Vegetable", "Meat", "Fruit", "Seeds" };
        }

        public override ICollection<string> AcceptableFoods { get; set; }

        public override string AskForFood()
        {
            return HEN_SOUND;
        }

        public override void Eat(Food food)
        {
            base.Eat(food);
            this.Weight += WEIGHT_GAIN * food.Quantity;
        }
    }
}
