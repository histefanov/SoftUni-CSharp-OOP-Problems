using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private const string INVALID_SIDE_VALUE_EXC_MSG = "Height/width cannot be negative or zero.";
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                ValidateSide(value);
                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                ValidateSide(value);
                this.width = value;
            }
        }

        private void ValidateSide(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException(INVALID_SIDE_VALUE_EXC_MSG);
            }
        }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }

        public override string Draw()
        {
            return base.Draw() + " " + this.GetType().Name;
        }
    }
}
