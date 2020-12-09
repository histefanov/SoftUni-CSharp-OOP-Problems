using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage _garage;
        private IProcedure _chip;
        private IProcedure _charge;
        private IProcedure _polish;
        private IProcedure _rest;
        private IProcedure _techCheck;
        private IProcedure _work;

        public Controller()
        {
            _garage = new Garage();
            _chip = new Chip();
            _charge = new Charge();
            _polish = new Polish();
            _rest = new Rest();
            _techCheck = new TechCheck();
            _work = new Work();
        }

        public string Charge(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);

            _charge.DoService(_garage.Robots[robotName], procedureTime);

            return String.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);

            _chip.DoService(_garage.Robots[robotName], procedureTime);

            return String.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string History(string procedureType)
        {
            var result = string.Empty;

            switch (procedureType)
            {
                case "Charge": result = _charge.History(); break;
                case "Chip": result = _chip.History(); break;
                case "Polish": result = _polish.History(); break;
                case "Rest": result = _rest.History(); break;
                case "TechCheck": result = _techCheck.History(); break;
                case "Work": result = _work.History(); break;
                default: break;
            }

            return result;
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = robotType switch
            {
                "HouseholdRobot" => new HouseholdRobot(name, energy, happiness, procedureTime),
                "PetRobot" => new PetRobot(name, energy, happiness, procedureTime),
                "WalkerRobot" => new WalkerRobot(name, energy, happiness, procedureTime),
                _ => throw new ArgumentException(
                    String.Format(ExceptionMessages.InvalidRobotType, robotType))
            };

            _garage.Manufacture(robot);

            return String.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);

            _polish.DoService(_garage.Robots[robotName], procedureTime);

            return String.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);

            _rest.DoService(_garage.Robots[robotName], procedureTime);

            return String.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            CheckIfRobotExists(robotName);

            bool isChipped = _garage.Robots[robotName].IsChipped;
            _garage.Sell(robotName, ownerName);

            return isChipped ? 
                $"{ownerName} bought robot with chip" : $"{ownerName} bought robot without chip";
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);

            _techCheck.DoService(_garage.Robots[robotName], procedureTime);

            return String.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);

            _work.DoService(_garage.Robots[robotName], procedureTime);

            return String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        private void CheckIfRobotExists(string robotName)
        {
            if (!_garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(
                    String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }
    }
}
