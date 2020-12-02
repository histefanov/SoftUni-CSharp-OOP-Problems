﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public class DesktopComputer : Computer, IComputer
    {
        private const double OVERALL_PERFORMANCE = 15;

        public DesktopComputer(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, OVERALL_PERFORMANCE)
        {

        }
    }
}
