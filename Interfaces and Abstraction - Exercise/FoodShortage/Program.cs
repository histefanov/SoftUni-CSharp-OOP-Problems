using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var consumers = new List<IBuyer>();
            string consoleInput;

            for (int i = 0; i < n; i++)
            {
                consoleInput = Console.ReadLine();
                string[] info = consoleInput.Split();
                string name = info[0];
                int age = int.Parse(info[1]);

                if (info.Length == 3)
                {
                    string group = info[2];
                    consumers.Add(new Rebel(name, age, group));
                }
                else
                {
                    string id = info[2];
                    string birthdate = info[3];
                    consumers.Add(new Citizen(name, age, id, birthdate));
                }
            }

            while ((consoleInput = Console.ReadLine()) != "End")
            {
                var currentBuyer = consumers.Find(c => c.Name == consoleInput);

                if (currentBuyer != null)
                {
                    currentBuyer.BuyFood();
                }
            }

            var boughtFood = consumers
                .Select(c => c.Food)
                .Sum();

            Console.WriteLine(boughtFood);
        }
    }
}
