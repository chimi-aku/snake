using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;

namespace snake
{
    class Game
    {
        TextColor textColor = TextColor.WHITE;


        public void Start()
        {
            runMainMenu();
            WriteLine("Press any key to exit");
            ReadKey(true);

        }

        private void runMainMenu()
        {
            Console.CursorVisible = false;

            if (textColor == TextColor.WHITE)
                ForegroundColor = ConsoleColor.White;
            else if (textColor == TextColor.GREEN) 
                ForegroundColor = ConsoleColor.Green;
            else if (textColor == TextColor.BLUE)
                ForegroundColor = ConsoleColor.Blue;

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
            string[] options = { "Play", "Options", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options, textColor);
            int selectedIndex = mainMenu.run();

            switch (selectedIndex)
            {
                case 0:
                    startGame();
                    break;
                case 1:
                    runSettingsMenu();
                    break;
                case 2:
                    displayInfoAboutGame();
                    break;
                case 3:
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

            WriteGameOver();
            Console.ReadLine();
            runMainMenu();
        }

        private void runSettingsMenu()
        {
            Clear();

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
                                            

Change your game experience!
(Use arrow keys to choose options.)";
            String[] options = { "Text Color", "Back" };
            Menu settingsMenu = new Menu(prompt, options, textColor);
            int selectedIndex = settingsMenu.run();


            switch (selectedIndex)
            {
                case 0:
                    changeTextColor();
                    break;
                case 1:
                    runMainMenu();
                    break;
            }

        }

        private void changeTextColor()
        {
            Clear();

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
                                            

Change text color!
(Use arrow keys to choose options.)";
            String[] options = { "White", "Green", "Blue", "Back" };
            Menu settingsMenu = new Menu(prompt, options, textColor);
            int selectedIndex = settingsMenu.run();


            switch (selectedIndex)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.White;
                    textColor = TextColor.WHITE;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    textColor = TextColor.GREEN;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    textColor = TextColor.BLUE;
                    break;
                case 3:
                    runMainMenu();
                    break;
            }

            runSettingsMenu();
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
            //WriteLine("\n\nPress any key to exit...");
            //ReadKey(true);
            Environment.Exit(0);
        }

        static void WriteGameOver()
        {
            Console.SetCursorPosition(17, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lose :( . Press 'enter' to return to main menu.");
        }
    }
}
