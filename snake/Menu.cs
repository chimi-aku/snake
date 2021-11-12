using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;

namespace snake
{
    class Menu
    {
        private int selectedIndex;
        private string[] options;
        private string prompt;
        private TextColor textColor; // text color

        public Menu(string prompt, string[] options, TextColor textColor)
        {
            this.prompt = prompt;
            this.options = options;
            this.textColor = textColor;
            this.selectedIndex = 0;
        }

        private void displayOptions()
        {
            WriteLine(prompt);
            for (int i = 0; i < options.Length; i++)
            {
                string currentOption = options[i];
                string prefix;

                if (i == selectedIndex)
                {
                    prefix = "*";

                    if (textColor == TextColor.WHITE)
                        ForegroundColor = ConsoleColor.White;
                    else if (textColor == TextColor.GREEN)
                        ForegroundColor = ConsoleColor.Green;
                    else if (textColor == TextColor.BLUE)
                       ForegroundColor = ConsoleColor.Blue;


                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";

                    if (textColor == TextColor.WHITE)
                        ForegroundColor = ConsoleColor.White;
                    else if (textColor == TextColor.GREEN)
                        ForegroundColor = ConsoleColor.Green;
                    else if (textColor == TextColor.BLUE)
                        ForegroundColor = ConsoleColor.Blue;

                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"{prefix} << {currentOption} >>");
            }

            //ResetColor();
        }

        public int run()
        {
            ConsoleKey keyPressed;

            do
            {
                Clear();
                displayOptions();
                bool isKeyDown = false;

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
                Thread.Sleep(100);

                // Update selectedIndex based on arrow keys.
                if(keyPressed == ConsoleKey.UpArrow && !isKeyDown)
                {
                    isKeyDown = true;
                    selectedIndex--;
                    if (selectedIndex == -1) selectedIndex = options.Length - 1;
                }
                else if(keyPressed == ConsoleKey.DownArrow && !isKeyDown)
                {
                    isKeyDown = true;
                    selectedIndex++;
                    if (selectedIndex == options.Length) selectedIndex = 0;
                }
                
            }
            while (keyPressed != ConsoleKey.Enter);

            return selectedIndex;
        }
    }
}
