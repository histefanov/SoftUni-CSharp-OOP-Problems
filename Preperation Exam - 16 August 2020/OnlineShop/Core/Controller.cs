using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// POSSIBLE USING MISSING (COMPONENT....)

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> _computers;
        private readonly List<IComponent> _components;
        private readonly List<IPeripheral> _peripherals;

        public Controller()
        {
            _computers = new List<IComputer>();
            _components = new List<IComponent>();
            _peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfComputerExists(computerId);

            if (_components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = componentType switch
            {
                "CentralProcessingUnit" => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                "Motherboard" => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                "PowerSupply" => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                "RandomAccessMemory" => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance,generation),
                "SolidStateDrive" => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                "VideoCard" => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            _components.Add(component);
            _computers
                .Find(c => c.Id == computerId)
                .AddComponent(component);

            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }


        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computerType != "DesktopComputer" &&
                computerType != "Laptop")
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            if (_computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer;

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                computer = new Laptop(id, manufacturer, model, price);
            }

            _computers.Add(computer);
            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfComputerExists(computerId);

            if (_peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = peripheralType switch
            {
                "Headset" => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                "Keyboard" => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                "Monitor" => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                "Mouse" => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            _peripherals.Add(peripheral);
            _computers.
                Find(c => c.Id == computerId)
                .AddPeripheral(peripheral);

            return String.Format(SuccessMessages.AddedPeripheral,
                peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            var computer = _computers
                .OrderByDescending(c => c.OverallPerformance)
                .FirstOrDefault(c => c.Price <= budget);

            if (computer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            _computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckIfComputerExists(id);

            var computer = _computers.FirstOrDefault(c => c.Id == id);
            var result = computer.ToString();

            _computers.Remove(computer);
            return result;
        }

        public string GetComputerData(int id)
        {
            CheckIfComputerExists(id);

            return _computers.Find(c => c.Id == id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfComputerExists(computerId);

            var computer = _computers.Find(c => c.Id == computerId);
            var removedComponent = computer.RemoveComponent(componentType);
            _components.Remove(removedComponent);

            return String.Format(SuccessMessages.RemovedComponent,
                componentType, removedComponent.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfComputerExists(computerId);

            var computer = _computers.Find(c => c.Id == computerId);
            var removedPeripheral = computer.RemovePeripheral(peripheralType);
            _peripherals.Remove(removedPeripheral);

            return String.Format(SuccessMessages.RemovedPeripheral,
                peripheralType, removedPeripheral.Id);
        }

        private void CheckIfComputerExists(int id)
        {
            if (!_computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
