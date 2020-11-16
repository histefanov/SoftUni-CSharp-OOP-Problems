namespace P04.Recharge
{
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string _id) 
            : base(_id)
        {
        }

        public void Sleep()
        {
            // sleep...
        }
    }
}
