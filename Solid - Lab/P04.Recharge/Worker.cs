namespace P04.Recharge
{
    public abstract class Worker
    {
        private string id;
        private int workingHours;

        public Worker(string _id)
        {
            this.id = _id;
        }

        public virtual void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}