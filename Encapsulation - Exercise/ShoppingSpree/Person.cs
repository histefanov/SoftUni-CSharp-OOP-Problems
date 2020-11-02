using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money 
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> BagOfProducts { get => this.bagOfProducts.AsReadOnly(); }

        public void BuyProduct(Product product)
        {
            if (this.money < product.Cost)
            {
                throw new InvalidOperationException($"{this.name} can't afford {product.Name}");
            }

            this.money -= product.Cost;
            this.bagOfProducts.Add(product);
            Console.WriteLine($"{this.name} bought {product.Name}");
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.name} - ");
            if (bagOfProducts.Count > 0)
            {
                var products = this.bagOfProducts.Select(p => p.Name);
                sb.Append(string.Join(", ", products));
            }
            else
            {
                sb.Append("Nothing bought");
            }

            return sb.ToString().Trim();
        }
    }
}
