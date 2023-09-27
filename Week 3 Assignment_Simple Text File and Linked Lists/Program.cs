using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_3_Assignment_Simple_Text_File_and_Linked_Lists.LinkedList_Classes;

namespace Week_3_Assignment_Simple_Text_File_and_Linked_Lists
{
    internal class Program
    {
        //https://stackoverflow.com/questions/41666625/c-sharp-can-you-call-an-enum-by-the-number-value
        //Showed how to call enums based on an integer instead.
        static void Main(string[] args)
        {
            Game game = new Game();
            game.InitGame();
        }
    }
}
