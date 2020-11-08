using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Soldier> army = new List<Soldier>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();
                string soldierType = info[0];
                string id = info[1];
                string firstName = info[2];
                string lastName = info[3];
                decimal salary = decimal.Parse(info[4]);
                string corps;

                switch (soldierType)
                {
                    case "Private":
                        army.Add(new Private(id, firstName, lastName, salary));
                        break;

                    case "LieutenantGeneral":
                        var lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                        for (int i = 5; i < info.Length; i++)
                        {
                            string privateId = info[i];
                            lieutenantGeneral.Privates.Add((Private)army.Find(p => p.Id == privateId));
                        }

                        army.Add(lieutenantGeneral);
                        break;

                    case "Engineer":
                        corps = info[5];
                        try
                        {
                            var engineer = new Engineer(id, firstName, lastName, salary, corps);

                            for (int i = 6; i < info.Length; i += 2)
                            {
                                string partName = info[i];
                                int workHours = int.Parse(info[i + 1]);
                                engineer.Repairs.Add(new Repair(partName, workHours));
                            }

                            army.Add(engineer);
                        }
                        catch (ArgumentException) { }
                        break;

                    case "Commando":
                        corps = info[5];
                        try
                        {
                            var commando = new Commando(id, firstName, lastName, salary, corps);

                            for (int i = 6; i < info.Length; i += 2)
                            {
                                string codeName = info[i];
                                string state = info[i + 1];

                                try
                                {
                                    commando.Missions.Add(new Mission(codeName, state));
                                }
                                catch (ArgumentException) { }
                            }

                            army.Add(commando);
                        }
                        catch (ArgumentException) { }
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(info[4]);
                        army.Add(new Spy(id, firstName, lastName, codeNumber));
                        break;

                    default: break;
                }
            }

            foreach (var soldier in army)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
