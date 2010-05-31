using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public enum Food
    {
        None = 0,
        Apple,
        Orange
    }

    public class Arena
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public SnakeModel Snake {get; set;}

        public Food[,] Cells { get; private set; }
        private Random random = new Random();

        public Arena(int width, int height)
        {
            Width = width;
            Height = height;

            Cells = new Food[width, height];

            Snake = new SnakeModel(this);

        }

        public void Update()
        {
            Snake.Move();
            if (random.Next(100) <= 4)
            {
                CreateFood();
            }
        }

        public void CreateFood()
        {
            Cells[random.Next(0, Width), random.Next(0, Height)] = (Food)random.Next(1, 3);
        }
    }
}
