using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; set; }

        public void CompleteMission(string codeName)
        {
            Missions.Find(m => m.CodeName == codeName).State = "Finished";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions: ");
            this.Missions.ForEach(m => sb.AppendLine($"  {m}"));

            return sb.ToString().TrimEnd();
        }
    }
}
