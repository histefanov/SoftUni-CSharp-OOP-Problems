using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Watermelon : Food
    {
        private const int POINTS = 3;
        private const char SYMBOL = '\u0398';
        private const ConsoleColor COLOR = ConsoleColor.Red;

        public Watermelon(Wall wall)
            : base(wall, SYMBOL, POINTS, COLOR)
        {
        }
    }
}
