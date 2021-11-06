using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class VerticalLine : Figure
    {
        public VerticalLine(int yTop, int yDown, int x, char sym)
        {
            pointsList = new List<Point>();

            for (int y = yTop; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pointsList.Add(p);
            }
        }
    }
}
