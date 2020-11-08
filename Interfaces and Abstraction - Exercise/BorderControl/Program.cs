using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var newcomers = new List<IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] subjectInfo = input.Split();
                string id = subjectInfo.Last();

                if (subjectInfo.Length == 3)
                {
                    string name = subjectInfo[0];
                    int age = int.Parse(subjectInfo[1]);
                    newcomers.Add(new Citizen(name, age, id));
                }
                else
                {
                    string model = subjectInfo[0];
                    newcomers.Add(new Robot(model, id));
                }
            }

            var giveaway = Console.ReadLine();

            foreach (var subject in newcomers)
            {
                if (subject.Id.EndsWith(giveaway))
                {
                    Console.WriteLine(subject.Id);
                }
            }
        }
    }
}
