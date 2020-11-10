using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;

        }

        public string Name { get; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public abstract ICollection<string> AcceptableFoods { get; set; }

        public abstract string AskForFood();

        public virtual void Eat(Food food)
        {
            if (!this.AcceptableFoods.Contains(food.GetType().Name))
            {
                throw new ArgumentException(
                    $"{this.GetType().Name} does not eat {food.GetType().Name}!");            
            }
            this.FoodEaten += food.Quantity;
        }
    }
}
