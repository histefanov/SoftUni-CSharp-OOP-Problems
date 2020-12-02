using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public int Price { get; set; }

        public void IncreasePrice(int amount)
        {
            Price += amount;
            Console.WriteLine($"The price of {Name} has been increased by {amount}.");
        }

        public void DecreasePrice (int amount)
        {
            if (amount < Price)
            {
                Price -= amount;
                Console.WriteLine($"The price of {Name} has been decreased by {amount}.");
            }
        }

        public override string ToString()
        {
            return $"Current price of {Name} is {Price}.";
        }
    }
}
