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
        static void WriteCentered(string prompt)
        {
        }


        public static void Prompt(string question)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(question);
            Console.ResetColor();
        }

        public static void Answer(string answer)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(answer);
            Console.ResetColor();
        }
    }
}
