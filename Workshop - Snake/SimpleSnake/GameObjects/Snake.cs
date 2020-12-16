using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
        private Random random;
        private const char SNAKE_SYMBOL = '\u25CF';

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];
            this.random = new Random();
            this.foodIndex = RandomFoodNumber;
            this.Level = 0;
            this.GetFoods();
            this.CreateSnake();
            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }

        public int Score { get; private set; }

        public int Level { get; private set; }

        public int RandomFoodNumber
            => this.random.Next(0, this.foods.Length);

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            foods[0] = new Apple(this.wall);
            foods[1] = new Orange(this.wall);
            foods[2] = new Watermelon(this.wall);
        }

        public bool IsMoving(Point direction)
        {
            Point currentHeadPosition = this.snakeElements.Last();

            GetNextPoint(direction, currentHeadPosition);

            bool isPointOfSnake = this.snakeElements
                .Any(s => s.LeftX == this.nextLeftX && s.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            Console.ForegroundColor = ConsoleColor.Green;
            snakeNewHead.Draw(SNAKE_SYMBOL);
            Console.ForegroundColor = ConsoleColor.Black;

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentHeadPosition);
            }

            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(' ');
            return true;
        }

        private void Eat(Point direction, Point currentHeadPosition)
        {
            this.Level++;
            this.Score += foods[foodIndex].FoodPoints;

            this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
            GetNextPoint(direction, currentHeadPosition);

            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }
    }
}
