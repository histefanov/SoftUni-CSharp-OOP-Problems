using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        private const string OWL_SOUND = "Hoot Hoot";
        private const double WEIGHT_GAIN = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.AcceptableFoods = new HashSet<string> { "Meat" };
        }

        public override ICollection<string> AcceptableFoods { get; set; }

        public override string AskForFood()
        {
            return OWL_SOUND;
        }

        public override void Eat(Food food)
        {
            base.Eat(food);
            this.Weight += WEIGHT_GAIN * food.Quantity;
        }
    }
}
