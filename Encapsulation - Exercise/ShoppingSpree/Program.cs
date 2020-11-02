using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] peopleData = Console.ReadLine()
                .Split(';');
            string[] productsData = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                foreach (var person in peopleData)
                {
                    string[] data = person.Split('=');
                    people.Add(new Person(data[0], decimal.Parse(data[1])));
                }

                foreach (var product in productsData)
                {
                    string[] data = product.Split('=');
                    products.Add(new Product(data[0], decimal.Parse(data[1])));
                }

                string cmd;
                while ((cmd = Console.ReadLine()) != "END")
                {
                    string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var person = people.FirstOrDefault(p => p.Name == tokens[0]);
                    var product = products.FirstOrDefault(p => p.Name == tokens[1]);

                    try
                    {
                        person.BuyProduct(product);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }                     
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            people.ForEach(p => Console.WriteLine(p));
        }
    }
}
