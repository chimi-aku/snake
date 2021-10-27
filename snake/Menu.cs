﻿using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace snake
{
    class Menu
    {
        private int selectedIndex;
        private string[] options;
        private string prompt;

        public Menu(string prompt, string[] options)
        {
            this.prompt = prompt;
            this.options = options;
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
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"{prefix} << {currentOption} >>");
            }

            ResetColor();
        }

        public int run()
        {
            ConsoleKey keyPressed;

            do
            {
                Clear();
                displayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                // Update selectedIndex based on arrow keys.
                if(keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == -1) selectedIndex = options.Length - 1;
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length) selectedIndex = 0;
                }

                
            }
            while (keyPressed != ConsoleKey.Enter);

            return selectedIndex;
        }
    }
}
