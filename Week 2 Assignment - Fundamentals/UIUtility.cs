using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_Assignment___Fundamentals
{
    static public class UIUtility
    {
        static void Center(string prompt)
        {//Centers the strings into the screen
            int centerAmount = Console.WindowWidth / 2;// Determine mid-point of the screen
            centerAmount -=prompt.Length/2; //Determine midpoint of the prompt, then subtract from screen.

            for(int i = 0; i < centerAmount; i++)
                Console.Write(" "); //Write the spaces in order to center the string

            Console.WriteLine(prompt); //Write the string.
        }


        public static void Prompt(string question)
        {//Color for prompts
            Console.ForegroundColor = ConsoleColor.Cyan;
            Center(question);
            Console.ResetColor();
        }

        public static void Answer(string answer)
        {//Color for answers
            Console.ForegroundColor = ConsoleColor.White;
            Center(answer);
            Console.ResetColor();
            Console.WriteLine("\n");
        }
    }
}
