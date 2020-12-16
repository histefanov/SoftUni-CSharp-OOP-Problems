using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WALL_SYMBOL = '\u25A0';

        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLine(1);
            SetHorizontalLine(TopY);

            SetVerticalLine(1);
            SetVerticalLine(LeftX - 1);
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 1; leftX < LeftX; leftX++)
            {
                Draw(leftX, topY, WALL_SYMBOL);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 1; topY < TopY; topY++)
            {
                Draw(leftX, topY, WALL_SYMBOL);
            }
        }

        public bool IsPointOfWall(Point snakeHead)
        {
            return snakeHead.LeftX == 1 || snakeHead.TopY == 1 ||
                   snakeHead.LeftX == this.LeftX - 1 || snakeHead.TopY == this.TopY;
        }
    }
}
