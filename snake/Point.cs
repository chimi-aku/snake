using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class Point
    {
        public int x;
        public int y;
        public char symbol;

        public Point()
        {

        }

        public Point(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            symbol = p.symbol;
        }

        public void move(int offset, Direction direction)
        {
            if (direction == Direction.LEFT)
            {
                x -= offset;
            }
            else if (direction == Direction.RIGHT)
            {
                x += offset;
            }
            else if (direction == Direction.UP)
            {
                y -= offset;
            }
            else if (direction == Direction.DOWN)
            {
                y += offset;
            }
        }

        public bool isHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }

        public void draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        public void clear()
        {
            symbol = ' ';
            draw();
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + symbol;
        }
    }
}
