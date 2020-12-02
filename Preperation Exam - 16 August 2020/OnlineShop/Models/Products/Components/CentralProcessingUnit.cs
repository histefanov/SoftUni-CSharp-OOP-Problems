using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class CentralProcessingUnit : Component, IComponent
    {
        private const double CPU_MULTIPLIER = 1.25;

        public CentralProcessingUnit(
            int id, 
            string manufacturer, 
            string model, 
            decimal price, 
            double overallPerformance, 
            int generation)
                : base(id, manufacturer, model, price, overallPerformance, generation)
        {
            
        }

        public override double OverallPerformance { get => base.OverallPerformance * CPU_MULTIPLIER; }
    }
}
