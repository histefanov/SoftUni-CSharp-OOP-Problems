using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Apple : Food
    {
        private const int POINTS = 1;
        private const char SYMBOL = '\u00F3';
        private const ConsoleColor COLOR = ConsoleColor.Green;

        public Apple(Wall wall)
            : base(wall, SYMBOL, POINTS, COLOR)
        {
        }     
    }
}
