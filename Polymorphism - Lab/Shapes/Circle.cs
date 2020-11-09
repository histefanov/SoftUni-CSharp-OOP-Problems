using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private const string INVALID_RADIUS_VALUE_EXC_MSG = "Radius cannot be negative or zero.";
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                ValidateRadius(value);
                this.radius = value;
            }
        }

        private void ValidateRadius(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException(INVALID_RADIUS_VALUE_EXC_MSG);
            }
        }

        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override string Draw()
        {
            return base.Draw() + " " + this.GetType().Name;
        }
    }
}
