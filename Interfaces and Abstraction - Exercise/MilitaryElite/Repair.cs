namespace MilitaryElite
{
    public class Repair : IRepair
    {
        public Repair(string partName, int workHours)
        {
            PartName = partName;
            WorkHours = workHours;
        }

        public string PartName { get; set; }
        public int WorkHours { get; set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.WorkHours}";
        }
    }
}