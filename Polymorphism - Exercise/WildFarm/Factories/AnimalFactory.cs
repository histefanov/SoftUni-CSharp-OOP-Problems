using System;
using System.Collections.Generic;
using System.Text;

using WildFarm.Models;

namespace WildFarm.Factories
{
    public static class AnimalFactory
    {
        public static Animal CreateAnimal(string[] info)
        {
            string type = info[0];
            string name = info[1];
            double weight = double.Parse(info[2]);
            double wingSize;
            string livingRegion;
            string breed;

            switch (type)
            {
                case "Owl":
                    wingSize = double.Parse(info[3]);
                    return new Owl(name, weight, wingSize);

                case "Hen":
                    wingSize = double.Parse(info[3]);
                    return new Hen(name, weight, wingSize);

                case "Mouse":
                    livingRegion = info[3];
                    return new Mouse(name, weight, livingRegion);
                    
                case "Dog":
                    livingRegion = info[3];
                    return new Dog(name, weight, livingRegion);
                    
                case "Cat":
                    livingRegion = info[3];
                    breed = info[4];
                    return new Cat(name, weight, livingRegion, breed);

                case "Tiger":
                    livingRegion = info[3];
                    breed = info[4];
                    return new Tiger(name, weight, livingRegion, breed);

                default: throw new ArgumentException("Invalid animal type");
            }
        }
    }
}
