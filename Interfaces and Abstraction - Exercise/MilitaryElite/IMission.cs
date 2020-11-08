namespace MilitaryElite
{
    public interface IMission
    {
        public string CodeName { get; set; }
        public string State { get; set; }

        public void CompleteMission();
    }
}