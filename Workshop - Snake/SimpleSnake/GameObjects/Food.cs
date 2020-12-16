using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Wall wall;
        private Random random;

        protected Food(Wall wall, char foodSymbol, int foodPoints, ConsoleColor foodColor) 
            : base(wall.LeftX, wall.TopY)
        {
            this.random = new Random();
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = foodPoints;
            this.FoodColor = foodColor;
        }

        public int FoodPoints { get; private set; }

        public ConsoleColor FoodColor { get; private set; }

        public void SetRandomPosition(Queue<Point> snake)
        {
            this.LeftX = random.Next(2, wall.LeftX - 2);
            this.TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnake = snake.Any(
                s => s.LeftX == this.LeftX && s.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = random.Next(2, wall.LeftX - 2);
                this.TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snake.Any(
                    s => s.LeftX == this.LeftX && s.TopY == this.TopY);
            }

            Console.BackgroundColor = FoodColor;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snakeHead)
        {
            return snakeHead.TopY == this.TopY &&
                   snakeHead.LeftX == this.LeftX;
        }
    }
}
