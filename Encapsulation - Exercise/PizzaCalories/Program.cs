using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string[] doughInfo = Console.ReadLine().Split();

                var dough = new Dough(doughInfo[1], doughInfo[2], int.Parse(doughInfo[3]));
                var pizza = new Pizza(pizzaInfo[1], dough);

                string toppingInput;
                while ((toppingInput = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = toppingInput.Split();
                    var topping = new Topping(toppingInfo[1], int.Parse(toppingInfo[2]));
                    pizza.AddTopping(topping);
                }
                              
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
