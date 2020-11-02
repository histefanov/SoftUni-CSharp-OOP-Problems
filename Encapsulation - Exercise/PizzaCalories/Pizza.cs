using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private readonly Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
            this.dough = dough;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public List<Topping> Toppings { get; set; }

        public double Calories 
        {
            get
            {                
                double totalCalories = 
                    this.dough.Calories + this.Toppings.Select(t => t.Calories).Sum();
                return totalCalories;
            }  
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            Toppings.Add(topping);
        }
    }
}
