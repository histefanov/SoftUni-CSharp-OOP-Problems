using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] tokens = cmd.Split(';');
                string action = tokens[0];
                string teamName = tokens[1];
                string playerName;

                try
                {
                    switch (action)
                    {
                        case "Team":
                            teams.Add(new Team(teamName));
                            break;

                        case "Add":
                            playerName = tokens[2];
                            int endurance = int.Parse(tokens[3]);
                            int sprint = int.Parse(tokens[4]);
                            int dribble = int.Parse(tokens[5]);
                            int passing = int.Parse(tokens[6]);
                            int shooting = int.Parse(tokens[7]);
                           
                            if (teams.Exists(t => t.Name == teamName))
                            {
                                var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                teams.Find(t => t.Name == teamName).AddPlayer(player);
                            }
                            else
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            break;

                        case "Remove":
                            playerName = tokens[2];
                            teams.Find(t => t.Name == teamName).RemovePlayer(playerName);
                            break;

                        case "Rating":
                            var teamToShowcase = teams.Find(t => t.Name == teamName);
                            if (teamToShowcase != null)
                            {
                                Console.WriteLine($"{teamToShowcase.Name} - {teamToShowcase.Rating}");
                            }
                            else
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
