using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
    class ArenaView
    {
        public static void Render(Graphics graphics, Arena arena)
        {
            graphics.FillRectangle(Brushes.AliceBlue, 0, 0, arena.Width * 10, arena.Height * 10);
            for (int x = 0; x < arena.Width; x++)
            {
                for (int y = 0; y < arena.Height; y++)
                {
                    if (arena.Cells[x, y] == Food.Apple)
                    {
                        graphics.FillRectangle(Brushes.GreenYellow, x * 10, y * 10, 10, 10);
                    }
                    else if (arena.Cells[x, y] == Food.Orange)
                    {
                        graphics.FillRectangle(Brushes.Orange, x * 10, y * 10, 10, 10);
                    }
                }
            }

            bool up, down, left, right;

            LinkedListNode<Point> lastSegment = null;
            LinkedListNode<Point> currentSegment = arena.Snake.Body.First;
            LinkedListNode<Point> nextSegment;
            while (null != currentSegment)
            {
                up = down = left = right = false;
                nextSegment = currentSegment.Next;

                CompareSegment(currentSegment, lastSegment, ref up, ref down, ref left, ref right);
                CompareSegment(currentSegment, nextSegment, ref up, ref down, ref left, ref right);

                DrawSegment(graphics, currentSegment.Value.X, currentSegment.Value.Y, up, down, left, right);

                lastSegment = currentSegment;
                currentSegment = nextSegment;
            }

        }

        private static void CompareSegment(LinkedListNode<Point> currentSegment, LinkedListNode<Point> otherSegment,
            ref bool up, ref bool down, ref bool left, ref bool right)
        {
            if (currentSegment != null && otherSegment != null)
            {
                if (currentSegment.Value.Y > otherSegment.Value.Y)
                {
                    up = true;
                }

                if (currentSegment.Value.Y < otherSegment.Value.Y)
                {
                    down = true;
                }

                if (currentSegment.Value.X > otherSegment.Value.X)
                {
                    left = true;
                }

                if (currentSegment.Value.X < otherSegment.Value.X)
                {
                    right = true;
                }
            }
        }

        private static void DrawSegment(Graphics graphics, int x, int y, bool up, bool down, bool left, bool right)
        {
            // possible patterns:
            // D,R  D,U  D,L  R,U  R,L  U,L
            // +++  + +  +++  + +  +++  + +
            // +    + +    +  +           + 
            // + +  + +  + +  +++  +++  +++

            graphics.FillRectangle(Brushes.RosyBrown, x * 10, y * 10, 10, 10);

            Point upLeft = new Point(x*10,y*10);
            Point upRight = new Point(x*10+9, y*10);
            Point downLeft = new Point(x*10,y*10+9);
            Point downRight = new Point(x*10+9,y*10+9);

            if ((down && right) || (down && left) || (right && left))
            {
                graphics.DrawLine(Pens.Black, upLeft, upRight);
            }

            if ((down && right) || (down && up) || (right && up))
            {
                graphics.DrawLine(Pens.Black, upLeft, downLeft);
            }

            if ((down && up) || (down && left) || (up && left))
            {
                graphics.DrawLine(Pens.Black, upRight, downRight);
            }

            if ((right && up) || (right && left) || (up && left))
            {
                graphics.DrawLine(Pens.Black, downLeft, downRight);
            }
        }
    }
}
