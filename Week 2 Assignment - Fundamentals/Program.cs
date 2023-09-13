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
        /// <summary>
        /// Nehemiah Cedillo
        /// PROG 260 Data Design for Applications
        /// </summary>
        
        static void Main(string[] args)
        {
            GameInfo gameInfo = new GameInfo();

            //Help seperate actions and methods.
            DataFinder data = new DataFinder();

            ///Number of games
            //Getting the number of items in the Meta Data
            //Display on screen
            Prompt("Number of Games:");
            Answer($"{gameInfo.MetaData.Count}");


            ///Which games are the most frequent?
            Prompt("Which games are the most frequent?");
            Answer(data.DetermineFrequentGame(gameInfo));

            ///Which map names have the most number of characters excluding spaces, and which game they belong to?
            Prompt("Which map names have the most number of characters excluding spaces, and which game they belong to?");
            Answer(data.DetermineMapNameLengths(gameInfo));

            ///A dictionary that uses the Id Property as a Key and Info object as a value, then display all the information using a loop
            Prompt("A dictionary that uses the Id Property as a Key and Info object as a value, then display all the information using a loop");
            Answer(data.DictionaryList(gameInfo));

            ///The map names that have the letter z in them
            Prompt("The map names that have the letter z in them");
            List<string> list = data.MapsWithZ(gameInfo);
            foreach(string str in list)
                Answer($" - {str}");

            Console.ReadKey();
        }
    }
}
