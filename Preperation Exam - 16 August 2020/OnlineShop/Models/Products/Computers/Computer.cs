using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> _components;
        private List<IPeripheral> _peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this._components = new List<IComponent>();
            this._peripherals = new List<IPeripheral>();
        }

        public override decimal Price
        {
            get
            {
                var componentsPrice = this.Components
                    .Select(c => c.Price)
                    .Sum();

                var peripheralsPrice = this.Peripherals
                    .Select(p => p.Price)
                    .Sum();

                return base.Price + componentsPrice + peripheralsPrice;
            }
        }

        public override double OverallPerformance
        {
            get
            {
                return CalculateOverallPerformance();
            }
        }


        public IReadOnlyCollection<IComponent> Components
            => this._components;

        public IReadOnlyCollection<IPeripheral> Peripherals
            => this._peripherals;

        public void AddComponent(IComponent component)
        {
            var componentType = component.GetType().Name;

            if (this._components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent,
                    componentType,
                    this.GetType().Name,
                    this.Id));
            }

            this._components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            var peripheralType = peripheral.GetType().Name;

            if (this.Peripherals.Any(p => p.GetType().Name == peripheralType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral,
                    peripheralType,
                    this.GetType().Name,
                    this.Id));
            }

            this._peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = this.Components
                .FirstOrDefault(c => c.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent,
                    componentType,
                    this.GetType().Name,
                    this.Id));
            }

            this._components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = this.Peripherals
                .FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType,
                    this.GetType().Name,
                    this.Id));
            }

            this._peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine(String.Format(
                SuccessMessages.ComputerComponentsToString, this.Components.Count));

            foreach (var comp in this.Components)
            {
                sb.AppendLine($"  {comp}");
            }

            sb.AppendLine(String.Format(
                SuccessMessages.ComputerPeripheralsToString, 
                this.Peripherals.Count, 
                GetAveragePeripheralOverallPerformance()));

            foreach (var peripheral in this.Peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }

        private double GetAveragePeripheralOverallPerformance()
        {
            double result;

            if (this.Peripherals.Count == 0)
            {
                result = 0;
            }
            else
            {
                result = this.Peripherals.Average(p => p.OverallPerformance);
            }

            return result;
        }

        private double CalculateOverallPerformance()
        {
            if (this.Components.Count == 0)
            {
                return base.OverallPerformance;
            }

            var avgComponentOverallPerformance = this.Components
                .Average(c => c.OverallPerformance);

            var result = base.OverallPerformance + avgComponentOverallPerformance;
            return result;
        }
    }
}
