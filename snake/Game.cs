using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

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
            exitGame();
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
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }
    }
}
