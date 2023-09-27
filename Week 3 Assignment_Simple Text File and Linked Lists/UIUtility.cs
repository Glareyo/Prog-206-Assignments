using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_Assignment_Simple_Text_File_and_Linked_Lists
{
    /// <summary>
    /// This class is static, so that the game can quickly call upon a variety of print options for specific tasks
    /// or highlight specific moments and information.
    /// </summary>
    
    public static class UIUtility
    {
        public enum Directions { North,South,East,West };

        //Used to center strings
        static void CreateSpaces(string message)
        {
            //Get the window width and divide be two
            int spaces = Console.WindowWidth / 2;

            //Then get the length of the message and divide by two
            //Subtract from spaces.
            spaces -= (message.Length / 2);

            //This will center the string to the screen.
            string s = "";
            for (int i = 0; i < spaces; i++) s += " ";
            Console.Write(s);
        }

        //These methods are used to Make the strings the print out on the console appear centered.
        public static void CenterString(string message, bool inline)
        {
            CreateSpaces(message);
            if (inline) Console.Write(message);
            else Console.WriteLine(message);
        }
        public static void CenterString(string message, ConsoleColor highlight,bool inline)
        {
            CreateSpaces(message);
            Console.BackgroundColor = highlight;

            if (inline) Console.Write(message);
            else Console.WriteLine(message);
        }
        public static void CenterString_Underline(string message)
        {
            CreateSpaces(message);

            Console.WriteLine(message);
            CreateSpaces(message);
            for(int i = 0; i<message.Length;i++)
                Console.Write("-");
            Console.WriteLine();
        }


        public static void Prompt(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CenterString(message, false);
            Console.ResetColor();
        }
        public static void DisplayAction(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CenterString_Underline(message);
            
            Console.ResetColor();
        }


        //For if the player attempts to go into a wall, or cannot do a certain action.
        public static void UnaccessiblePrompt(string message = "You cannot go that way")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            CenterString(message, false);
            Console.ResetColor();
        }
        public static void InvalidInput(string message = " Invalid Input ")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            CenterString(message, ConsoleColor.White,false);
            Console.ResetColor();
        }
        
        //Allows user input
        public static string PromptAndAnswer(string message)
        {
            string answer = "";
            
            Console.ForegroundColor = ConsoleColor.Green;
            CenterString(message, true);
            Console.ForegroundColor = ConsoleColor.Magenta;

            answer = Console.ReadLine();

            Console.ResetColor();

            return answer;
        }
        
        
        //Multiple print options, such as being able to have different colors within a single line.
        public static void Print(string message, ConsoleColor color, bool centerString, bool inLine)
        {
            Console.ForegroundColor = color;
            if (centerString) CenterString(message, inLine);
            else if (inLine) Console.Write(message);
            else Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void Print_Underline(string message, ConsoleColor color, bool centerString)
        {
            Console.ForegroundColor = color;
            if (centerString)
                CenterString_Underline(message);
            else
            {
                Console.WriteLine(message);
                for (int i = 0; i < message.Length; i++) Console.Write("-");
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public static void Print(string m1, string m2, string m3, ConsoleColor c1, ConsoleColor c2, ConsoleColor c3,bool centerString, bool inLine)
        {
            if (centerString) CreateSpaces(m1+m2+ m3);
            
            Console.ForegroundColor = c1;
            Console.Write(m1);

            Console.ForegroundColor = c2;
            Console.Write(m2);

            Console.ForegroundColor = c3;
            if (inLine) Console.Write(m3);
            else Console.WriteLine(m3);
            
            Console.ResetColor();
        }
        public static void Print(string m1, string m2, string m3, string m4, ConsoleColor c1, ConsoleColor c2, ConsoleColor c3, ConsoleColor c4, bool centerString, bool inLine)
        {
            if (centerString) CreateSpaces(m1 + m2 + m3 + m4);

            Console.ForegroundColor = c1;
            Console.Write(m1);

            Console.ForegroundColor = c2;
            Console.Write(m2);

            Console.ForegroundColor = c3;
            Console.Write(m3);

            Console.ForegroundColor = c4;
            if (inLine) Console.Write(m4);
            else Console.WriteLine(m4);

            Console.ResetColor();
        }
        public static void Print(string[] messeges, ConsoleColor[] colors, bool centerString, bool inLine)
        {
            if (centerString)
            {
                string entireMessage = "";
                foreach (string m in messeges)
                    entireMessage += m;
                CreateSpaces(entireMessage);
            }
            for (int index = 0; index < messeges.Length - 1; index++)
            {
                Console.ForegroundColor = colors[index];
                Console.Write(messeges[index]);
            }

            //Final messege
            Console.ForegroundColor = colors.Last();
            if (inLine) Console.Write(messeges.Last());
            else Console.WriteLine(messeges.Last());

            Console.ResetColor();
        }
        public static void Print(List<string> messeges, List<ConsoleColor> colors, bool centerString, bool inLine)
        {
            if (centerString)
            {
                string entireMessage = "";
                foreach (string m in messeges)
                    entireMessage += m;
                CreateSpaces(entireMessage);
            }
            for (int index = 0; index < messeges.Count - 1; index++)
            {
                Console.ForegroundColor = colors[index];
                Console.Write(messeges[index]);
            }

            //Final messege
            Console.ForegroundColor = colors.Last();
            if (inLine) Console.Write(messeges.Last());
            else Console.WriteLine(messeges.Last());

            Console.ResetColor();
        }


        //Acts as a buffer for the player to continue forward.
        public static void Continue()
        {
            Console.WriteLine();
            Print("Press ", "Enter ", "to Continue", ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Green, true, false);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine();
        }

        //Create a full screen border
        public static void GenerateBorderLine()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write("-");
            Console.WriteLine();
        }
    }
}
