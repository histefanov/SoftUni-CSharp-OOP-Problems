using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalType;
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (age <= 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string gender = tokens[2];

                switch (animalType)
                {
                    case "Dog": animals.Add(new Dog(name, age, gender)); break;
                    case "Cat": animals.Add(new Cat(name, age, gender)); break;
                    case "Frog": animals.Add(new Frog(name, age, gender)); break;
                    case "Kitten": animals.Add(new Kitten(name, age)); break;
                    case "Tomcat": animals.Add(new Tomcat(name, age)); break;
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
