using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake
{
    class Snake : Figure
    {
        Direction direction;

        public Snake(Point tail, int lenght, Direction direction)
        {
            this.direction = direction;
            pointsList = new List<Point>();

            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);
                p.move(i, direction);
                pointsList.Add(p);
            }
        }

        internal void move()
        {
            Point tail = pointsList.First();
            pointsList.Remove(tail);
            Point head = getNextPoint();
            pointsList.Add(head);

            tail.clear();
            head.draw();
        }

        public Point getNextPoint()
        {
            Point head = pointsList.Last();
            Point nextPoint = new Point(head);
            nextPoint.move(1, direction);
            return nextPoint;
        }

        internal bool isHitTail()
        {
            var head = pointsList.Last();
            for (int i = 0; i < pointsList.Count - 2; i++)
            {
                if (head.isHit(pointsList[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void handleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow && direction != Direction.RIGHT)
            {
                direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow && direction != Direction.LEFT)
            {
                direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.DownArrow && direction != Direction.UP)
            {
                direction = Direction.DOWN;
            }
            else if (key == ConsoleKey.UpArrow && direction != Direction.DOWN)
            {
                direction = Direction.UP;
            }
        }

        internal bool eat(Point food)
        {
            Point head = getNextPoint();
            if (head.isHit(food))
            {
                food.symbol = head.symbol;
                pointsList.Add(food);
                return true;
            }
            else
                return false;
        }
    }
}
