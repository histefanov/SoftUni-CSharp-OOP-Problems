using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int CAPACITY = 10;
        private IDictionary<string, IRobot> _robots;

        public Garage()
        {
            _robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => (IReadOnlyDictionary<string, IRobot>)_robots;

        public void Manufacture(IRobot robot)
        {
            if (_robots.Count >= CAPACITY)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (_robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(
                    String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            _robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!_robots.ContainsKey(robotName))
            {
                throw new ArgumentException(
                    String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            _robots[robotName].Owner = ownerName;
            _robots[robotName].IsBought = true;
            _robots.Remove(robotName);
        }
    }
}
