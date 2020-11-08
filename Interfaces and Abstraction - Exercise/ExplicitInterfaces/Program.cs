using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var register = new List<Citizen>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var info = input.Split();
                register.Add(new Citizen(info[0], info[1], int.Parse(info[2])));
            }

            foreach (var citizen in register)
            {
                IPerson person = citizen;
                Console.WriteLine(person.GetName());
                IResident resident = citizen;
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
