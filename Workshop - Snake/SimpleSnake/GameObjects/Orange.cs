using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Orange : Food
    {
        private const int POINTS = 2;
        private const char SYMBOL = '\u00D5';
        private const ConsoleColor COLOR = ConsoleColor.Yellow;

        public Orange(Wall wall) 
            : base(wall, SYMBOL, POINTS, COLOR)
        {
        }
    }
}
