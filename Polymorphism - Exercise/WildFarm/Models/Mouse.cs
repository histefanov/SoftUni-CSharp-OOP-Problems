using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        private const string MOUSE_SOUND = "Squeak";
        private const double WEIGHT_GAIN = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.AcceptableFoods = new HashSet<string> { "Vegetable", "Fruit" };
        }

        public override ICollection<string> AcceptableFoods { get; set; }

        public override string AskForFood()
        {
            return MOUSE_SOUND;
        }

        public override void Eat(Food food)
        {
            base.Eat(food);
            this.Weight += WEIGHT_GAIN * food.Quantity;
        }
    }
}
