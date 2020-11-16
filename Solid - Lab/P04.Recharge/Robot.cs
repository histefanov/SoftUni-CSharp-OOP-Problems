using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
    public class Robot : Worker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string _id, int _capacity) 
            : base(_id)
        {
            this.capacity = _capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int CurrentPower
        {
            get { return this.currentPower; }
            set { this.currentPower = value; }
        }

        public override void Work(int hours)
        {
            if (hours > this.currentPower)
            {
                hours = currentPower;
            }

            base.Work(hours);
            this.currentPower -= hours;
        }

        public void Recharge()
        {
            this.currentPower = this.capacity;
        }
    }
}