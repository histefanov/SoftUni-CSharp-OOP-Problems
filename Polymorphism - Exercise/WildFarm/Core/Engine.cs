using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Factories;
using WildFarm.Models;

namespace WildFarm.Core
{
    public class Engine
    {
        private ICollection<Animal> farm;

        public Engine()
        {
            farm = new List<Animal>();
        }

        public void Run()
        {
            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                string[] animalData = line.Split();

                var currentAnimal = AnimalFactory.CreateAnimal(animalData);
                farm.Add(currentAnimal);

                string[] foodData = Console.ReadLine().Split();
                string foodType = foodData[0];
                int foodQuantity = int.Parse(foodData[1]);

                var currentFood = FoodFactory.CreateFood(foodType, foodQuantity);

                Console.WriteLine(currentAnimal.AskForFood());
                
                try
                {
                    currentAnimal.Eat(currentFood);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var animal in farm)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
