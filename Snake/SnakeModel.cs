using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Snake
{
    public enum Direction
    {
        Up, Down, Left, Right
    }

    public class SnakeModel
    {
        public LinkedList<Point> Body = new LinkedList<Point>();
        
        private Direction direction;
        private Arena arena;

        private int growth = 2;

        Point speed = new Point();

        public SnakeModel(Arena arena)
        {
            Body.AddLast(new Point(1, 1));

            this.arena = arena;
            ChangeDirection(Direction.Right);
        }

        public void Move()
        {
            Point newHead = GetNewHead();

            if (arena.Cells[newHead.X, newHead.Y] == Food.Apple)
            {
                growth += 2;
            }
            else if (arena.Cells[newHead.X, newHead.Y] == Food.Orange)
            {
                growth++;
            }
            arena.Cells[newHead.X, newHead.Y] = Food.None;

            if (growth > 0)
            {
                growth--;
            }
            else
            {
                Body.RemoveFirst();
            }
            Body.AddLast(newHead);
            Console.WriteLine(Body.ToString());
        }

        public void ChangeDirection(Direction newDirection)
        {
            switch (newDirection)
            {
                case Direction.Up:
                    if (direction != Direction.Down)
                    {
                        speed.X = 0;
                        speed.Y = -1;
                        direction = newDirection;
                    }
                    break;

                case Direction.Down:
                    if (direction != Direction.Up)
                    {
                        speed.X = 0;
                        speed.Y = 1;
                        direction = newDirection;
                    }
                    break;

                case Direction.Left:
                    if (direction != Direction.Right)
                    {
                        speed.X = -1;
                        speed.Y = 0;
                        direction = newDirection;
                    }
                    break;

                case Direction.Right:
                    if (direction != Direction.Left)
                    {
                        speed.X = 1;
                        speed.Y = 0;
                        direction = newDirection;
                    }
                    break;
            }
        }

        private Point GetNewHead()
        {
            Point head = Body.Last.Value;

            int newX = (head.X + speed.X) % arena.Width;
            if (newX < 0)
            {
                newX += arena.Width;
            }

            int newY = (head.Y + speed.Y) % arena.Height;
            if (newY < 0)
            {
                newY += arena.Height;
            }

            Point newHead = new Point(newX, newY);

            return newHead;
        }
    }
}
