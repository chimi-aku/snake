using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class Walls
    {
        List<Figure> wallsList;

        public Walls(int boardWidth, int boardHeight)
        {
            wallsList = new List<Figure>();

            HorizontalLine topLine = new HorizontalLine(0, boardWidth - 2, 0, '-');
            HorizontalLine bottomLine = new HorizontalLine(0, boardWidth - 2, boardHeight - 1, '-');
            VerticalLine leftLine = new VerticalLine(0, boardHeight - 1, 0, '|');
            VerticalLine rightLine = new VerticalLine(0, boardHeight - 1, boardWidth - 2, '|');

            wallsList.Add(topLine);
            wallsList.Add(bottomLine);
            wallsList.Add(leftLine);
            wallsList.Add(rightLine);
        }

        internal bool isHit(Figure figure)
        {
            foreach (var wall in wallsList)
            {
                if (wall.isHit(figure))
                {
                    return true;
                }
            }


            return false;
        }

        public void draw()
        {
            foreach (var wall in wallsList)
            {
                wall.draw();
            }
        }
    }
}
