using System;
using System.Collections.Generic;
using System.Text;

using WildFarm.Models;

namespace WildFarm.Factories
{
    public static class FoodFactory
    {
        public static Food CreateFood(string foodType, int quantity)
        {
            return foodType switch
            {
                "Vegetable" => new Vegetable(quantity),
                "Fruit" => new Fruit(quantity),
                "Meat" => new Meat(quantity),
                "Seeds" => new Seeds(quantity),
                _ => throw new ArgumentException("Invalid food type")
            };
        }
    }
}
