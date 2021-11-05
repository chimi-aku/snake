using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class Board
    {
        public int width { get; set; }
        public int height { get; set; }

        public Board()
        {
            width = 50;
            height = 25;
        }

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
        }


        public void drawBoard()
        {
            Console.Clear();

            /* drawing borders */
            for(int i = 1; i <= width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
            }

            for (int i = 1; i <= width; i++)
            {
                Console.SetCursorPosition(i, height + 1);
                Console.Write("-");
            }

            for (int i = 1; i <= height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
            }

            for (int i = 1; i <= height; i++)
            {
                Console.SetCursorPosition(width + 1, i);
                Console.Write("|");
            }

            /* drawing corners ┌ └ ┐ ┘*/
            Console.SetCursorPosition(0, 0);
            Console.Write("┌");
            Console.SetCursorPosition(width + 1, 0);
            Console.Write("┐");
            Console.SetCursorPosition(0, height + 1);
            Console.Write("└");
            Console.SetCursorPosition(width + 1, height + 1);
            Console.Write("┘");


        }

    }
}
