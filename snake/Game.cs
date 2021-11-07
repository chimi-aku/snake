using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;

namespace snake
{
    class Game
    {
        public void Start()
        {
            runMainMenu();
            WriteLine("Press any key to exit");
            ReadKey(true);

        }

        private void runMainMenu()
        {
            Console.CursorVisible = false;

            string prompt = @"

  ██████  ███▄    █  ▄▄▄       ██ ▄█▀▓█████ 
▒██    ▒  ██ ▀█   █ ▒████▄     ██▄█▒ ▓█   ▀ 
░ ▓██▄   ▓██  ▀█ ██▒▒██  ▀█▄  ▓███▄░ ▒███   
  ▒   ██▒▓██▒  █ ██▒░██▄▄▄▄██ ▓██ █▄ ▒▓█  ▄ 
▒██████▒▒▒██░   ▓██░ ▓█   ▓██▒▒██▒ █▄░▒████▒
▒ ▒▓▒ ▒ ░░ ▒░   ▒ ▒  ▒▒   ▓▒█░▒ ▒▒ ▓▒░░ ▒░ ░
░ ░▒  ░ ░░ ░░   ░ ▒░  ▒   ▒▒ ░░ ░▒ ▒░ ░ ░  ░
░  ░  ░     ░   ░ ░   ░   ▒   ░ ░░ ░    ░   
      ░           ░       ░  ░░  ░      ░  ░
                                            

Welcome to snake game. Have fun!
(Use arrow keys to choose options.)";
            string[] options = { "Play", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.run();

            switch (selectedIndex)
            {
                case 0:
                    startGame();
                    break;
                case 1:
                    displayInfoAboutGame();
                    break;
                case 2:
                    exitGame();
                    break;
            }

        }

        private void startGame()
        {
            

            WriteLine("Game is running...");
            Console.Clear();

            Walls walls = new Walls(80, 25);
            walls.draw();

            Point p = new Point(4, 6, '*');
            Snake snake = new Snake(p, 5, Direction.RIGHT);
            snake.draw();

            // creating first fruit
            FoodCreator foodCreator = new FoodCreator(80, 25, 'O');
            Point food = foodCreator.createFood();
            food.draw();

            while(true)
            {
                if (walls.isHit(snake) || snake.isHitTail())
                {
                    break;
                }

                if (snake.eat(food))
                {
                    food = foodCreator.createFood();
                    food.draw();
                }
                else
                {
                    snake.move();
                }


                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.handleKey(key.Key);
                }
            }

            Console.ReadLine();
            //exitGame();
        }

        private void displayInfoAboutGame()
        {
            Clear();
            WriteLine("Press any key to return to the main menu...");
            ReadKey(true);
            runMainMenu();
        }

        private void exitGame()
        {
            WriteLine("\n\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }
    }
}
