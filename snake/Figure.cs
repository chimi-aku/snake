using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class Figure
    {
        protected List<Point> pointsList;

        public void draw()
        {
            foreach (Point p in pointsList)
            {
                p.draw();
            }
        }

        internal bool isHit(Figure figure)
        {
            foreach (var p in pointsList)
            {
                if (figure.isHit(p))
                {
                    return true;
                }
            }
            return false;
        }

        private bool isHit(Point point)
        {
            foreach (Point p in pointsList)
            {
                if (p.isHit(point))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
