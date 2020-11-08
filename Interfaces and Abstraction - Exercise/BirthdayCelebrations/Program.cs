using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var birthRegister = new List<IBornable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] subjectInfo = input.Split();
                string subjectType = subjectInfo[0];

                switch (subjectType)
                {
                    case "Citizen":
                        birthRegister.Add(
                            new Citizen(subjectInfo[1], int.Parse(subjectInfo[2]), subjectInfo[3], subjectInfo[4]));
                        break;

                    case "Pet":
                        birthRegister.Add(
                            new Pet(subjectInfo[1], subjectInfo[2]));
                        break;

                    default: break;
                }
            }

            string referenceYear = Console.ReadLine();

            birthRegister
                .Where(s => s.Birthdate.EndsWith(referenceYear))
                .ToList()
                .ForEach(s => Console.WriteLine(s.Birthdate));
        }
    }
}
