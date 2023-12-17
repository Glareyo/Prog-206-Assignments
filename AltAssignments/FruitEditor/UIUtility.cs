using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace FruitEditor
{
    public static class UIUtility
    {
        static public Random rand = new Random();

        /// <summary>
        /// Writes a string while centered in the screen.
        /// </summary>
        /// <param name="prompt">Target string to write.</param>
        public static void CenterString(string prompt)
        {
            prompt = CreateCenStr(prompt, true);
            Console.WriteLine(prompt);

            Console.ResetColor();
        }

        /// <summary>
        /// Writes a string Centered with a particular color.
        /// </summary>
        /// <param name="prompt">Target string to write,</param>
        /// <param name="color">Which color to write in.</param>
        public static void CenterString(string prompt, ConsoleColor color)
        {
            prompt = CreateCenStr(prompt, true);
            Console.ForegroundColor = color;

            Console.WriteLine(prompt);

            Console.ResetColor();
        }

        /// <summary>
        /// Writes a string centered with a particular color and highlight
        /// </summary>
        /// <param name="prompt">Target string to write</param>
        /// <param name="color">Which color to write in.</param>
        /// <param name="highlight">Which color to highlight in.</param>
        public static void CenterString(string prompt, ConsoleColor color, ConsoleColor highlight)
        {
            string space = CreateCenStr(prompt,false); //Create a string that only has the required spaces to make it centered.
            Console.Write(space);

            Console.ForegroundColor = color;
            Console.BackgroundColor = highlight;
            Console.WriteLine(prompt);

            Console.ResetColor();
        }

        /// <summary>
        /// Writes a string in a prompt format.
        /// </summary>
        public static void Prompt(string prompt)
        {
            CenterString($"-{prompt}-", ConsoleColor.Magenta);
        }

        /// <summary>
        /// Writes a string saying there is an invalid input.
        /// </summary>
        public static void InvalidInput()
        {
            CenterString("INVALID INPUT", ConsoleColor.Red, ConsoleColor.DarkYellow);
        }

        /// <summary>
        /// Writes a string to notify a player of something.
        /// </summary>
        /// <param name="prompt">Target string to write.</param>
        public static void Notify(string prompt)
        {
            prompt = $"(--{prompt}--)";
            CenterString(prompt, ConsoleColor.Cyan,ConsoleColor.DarkBlue);
        }

        /// <summary>
        /// Creates the string required to make it centered.
        /// </summary>
        public static string CreateCenStr(string prompt,bool includePrompt)
        {
            string returnString = "";
            for(int i = 0; i < (Console.WindowWidth/2) - (prompt.Length/2); i++)
            {
                returnString += " ";
            }

            if (includePrompt)
                return returnString += prompt;
            else
                return returnString;
        }

        /// <summary>
        /// Gets the player input and returns the string.
        /// </summary>
        public static string GetInput()
        {
            string prompt = "";
            string inputBox = "Type Input:";

            string spaces = CreateCenStr(inputBox, false);

            //Write spaces without highlight
            Console.Write(spaces);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(inputBox);
            Console.ResetColor();

            Console.Write(" ");

            Console.ForegroundColor = ConsoleColor.Green;
            prompt = Console.ReadLine();

            Console.ResetColor();

            return prompt;
        }

        static public void Continue()
        {
            Notify("Press \"Enter\" to Continue");
            Console.ReadLine();
            Console.Clear();
        }




        static public int MenuPrompt(string[] prompts, string[] options)
        {
            bool runMenu = true;
            int currentOpt = 0;

            while (runMenu)
            {
                Console.Clear();

                foreach(string s in prompts)
                {
                    CenterString(s, ConsoleColor.Green);
                }
                MenuBar();


                // Print what the options are.
                for (int i = 0; i < options.Length; i++)
                {
                    if (currentOpt == i)
                    {
                        CenterString(options[i], ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                        CenterString(options[i], ConsoleColor.Red);
                }

                string playerInput = Console.ReadKey().Key.ToString();

                if (playerInput == ConsoleKey.UpArrow.ToString())
                    currentOpt--;
                else if (playerInput == ConsoleKey.DownArrow.ToString())
                    currentOpt++;
                else if (playerInput == ConsoleKey.Enter.ToString())
                    runMenu = false;

                if (currentOpt <= 0) currentOpt = 0;
                else if (currentOpt >= options.Length) currentOpt = options.Length - 1;

            }

            return currentOpt + 1;
        }
        static public int MenuPrompt(string prompt, string[] options)
        {
            bool runMenu = true;
            int currentOpt = 0;

            while (runMenu)
            {
                Console.Clear();
                CenterString(prompt, ConsoleColor.Green);
                MenuBar();


                // Print what the options are.
                for (int i = 0; i < options.Length; i++) 
                {
                    if (currentOpt == i)
                    {
                        CenterString(options[i], ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                        CenterString(options[i], ConsoleColor.Red);
                }

                string playerInput = Console.ReadKey().Key.ToString();

                if (playerInput == ConsoleKey.UpArrow.ToString())
                    currentOpt--;
                else if (playerInput == ConsoleKey.DownArrow.ToString())
                    currentOpt++;
                else if (playerInput == ConsoleKey.Enter.ToString())
                    runMenu = false;

                if (currentOpt <= 0) currentOpt = 0;
                else if (currentOpt >= options.Length) currentOpt = options.Length-1;

            }

            return currentOpt+1;

        }
        static public int MenuPrompt(string[] prompts, ConsoleColor[] colors, string[] options)
        {
            bool runMenu = true;
            int currentOpt = 0;

            while (runMenu)
            {
                Console.Clear();
                for(int i = 0; i < prompts.Length; i++)
                {
                    CenterString(prompts[i], colors[i]);
                }
                MenuBar();

                // Print what the options are.
                for (int i = 0; i < options.Length; i++)
                {
                    if (currentOpt == i)
                    {
                        CenterString(options[i], ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                        CenterString(options[i], ConsoleColor.Red);
                }

                string playerInput = Console.ReadKey().Key.ToString();

                if (playerInput == ConsoleKey.UpArrow.ToString())
                    currentOpt--;
                else if (playerInput == ConsoleKey.DownArrow.ToString())
                    currentOpt++;
                else if (playerInput == ConsoleKey.Enter.ToString())
                    runMenu = false;

                if (currentOpt <= 0) currentOpt = 0;
                else if (currentOpt >= options.Length) currentOpt = options.Length - 1;

            }

            return currentOpt + 1;
        }

        static void MenuBar()
        {
            CenterString("_________________________________________", ConsoleColor.Green);
            Notify("\'UP\' / \'DOWN\' : select.");
            Notify("\'Enter\' : Confirm.");
            CenterString("_________________________________________", ConsoleColor.Green);
        }

        static public void Debug(string prompt)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(prompt);
            Console.ResetColor();

            Continue();
        }
    }
}