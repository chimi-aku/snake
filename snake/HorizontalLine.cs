using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class HorizontalLine : Figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            pointsList = new List<Point>();

            for (int x = xLeft; x <= xRight; x++)
            {
                Point p = new Point(x, y, sym);
                pointsList.Add(p);
            }
        }
    }
}
