using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class RandomAccessMemory : Component, IComponent
    {
        private const double RAM_MULTIPLIER = 1.20;

        public RandomAccessMemory(
            int id,
            string manufacturer,
            string model,
            decimal price,
            double overallPerformance,
            int generation)
                : base(id, manufacturer, model, price, overallPerformance, generation)
        {
            
        }

        public override double OverallPerformance { get => base.OverallPerformance * RAM_MULTIPLIER; }
    }
}
