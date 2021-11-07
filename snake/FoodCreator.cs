using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class FoodCreator
    {
        int boardWidth;
        int boardHeight;
        char symbol;

        Random randNum = new Random();

        public FoodCreator (int boardWidth, int boardHeight, char symbol)
        {
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            this.symbol = symbol;
        }

        public Point createFood()
        {
            int x = randNum.Next(2, boardWidth - 2);
            int y = randNum.Next(2, boardHeight - 2);
            return new Point(x, y, symbol);
        }
    }
}
