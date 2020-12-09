using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private int _energy;
        private int _happiness;
        private int _prodedureTime;
        private string _owner;
        private bool _isBought;
        private bool _isChipped;
        private bool _isChecked;

        public Robot(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Happiness = happiness;
            Energy = energy;
            ProcedureTime = procedureTime;
            Owner = "Service";
            IsBought = false;
            IsChipped = false;
            IsChecked = false;
        }

        public string Name { get; }

        public int Happiness 
        { 
            get
            {
                return _happiness;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }
                _happiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return _energy;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }
                _energy = value;
            }
        }
        
        public int ProcedureTime { get { return _prodedureTime; } set { _prodedureTime = value; } }
       
        public string Owner { get { return _owner; } set { _owner = value; } }

        public bool IsBought { get { return _isBought; } set { _isBought = value; } }

        public bool IsChipped { get { return _isChipped; } set { _isChipped = value; } }

        public bool IsChecked { get { return _isChecked; } set { _isChecked = value; } }

        public override string ToString()
        {
            return $" Robot type: {GetType().Name} - {Name} - Happiness: {Happiness} - Energy: {Energy}";
        }
    }
}
