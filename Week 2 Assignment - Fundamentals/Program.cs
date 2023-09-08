using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Week_2_Assignment___Fundamentals.UIUtility;

namespace Week_2_Assignment___Fundamentals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameInfo gameInfo = new GameInfo();


            //Getting the number of items in the Meta Data
            int numOfGames = gameInfo.MetaData.Count;
            //Display on screen
            Prompt("Number of Games:");
            Answer($"{numOfGames}");

            //Getting all of the games.
            SortedList<string,int> genreList = new SortedList<string,int>();
            foreach (Info i in gameInfo.MetaData)
            {
                if (genreList.ContainsKey(i.Genre))
                {

                } 
            }

            Console.ReadKey();
        }
    }
}
