using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week_2_Assignment___Fundamentals
{
    public class DataFinder
    {
        public string DetermineFrequentGame(GameInfo gameInfo)
        {
            //Getting all of the games.
            string topFrequent = "";
            int numOfFrequents = 0;
            //Run through the entire list
            foreach (Info i in gameInfo.MetaData)
            {
                int tempCount = 0; //Temporary counter for current genre.
                foreach (Info a in gameInfo.MetaData)
                {//Compare currently selected genre with entire list.
                    if (i.Genre == a.Genre) tempCount += 1;
                }
                //Change top frequent name if there are more than the previous top frequent name.
                if (tempCount >= numOfFrequents)
                {
                    numOfFrequents = tempCount;
                    topFrequent = i.Genre;
                }
            }

            return topFrequent;
        }

        public string DetermineMapNameLengths(GameInfo gameInfo)
        {///Which map names have the most number of characters excluding spaces, and which game they belong to?
            string game = "";
            int length = 0;

            //Run through the entire list
            foreach (Info info in gameInfo.MetaData)
            {
                int tempCount = 0; //Temporary counter for current genre.

                //Run a loop through the string array
                foreach (string name in info.MapNames)
                {
                    //Begin running through each char in the string within the array.
                    for (int i = 0; i < name.Length; i++)
                        if (name[i] != ' ') tempCount += 1; //Add 1 if it is not a space.
                }

                //Change top name if there are more than the previous top name.
                if (tempCount >= length)
                {
                    length = tempCount;
                    game = info.Name;
                }
            }

            //Output
            string output = $"{game} contains the maps with the most chars, consisting of {length} chars in total";
            return output;
        }

        public string DictionaryList(GameInfo gameInfo)
        {
            string output = "";
            //Create the dictionary
            Dictionary<int, Info> GameDictionary = new Dictionary<int, Info>();

            //Use a loop to add the ids and info to dictionary
            foreach (Info info in gameInfo.MetaData)
                GameDictionary.Add(info.Id, info);

            //Run through the dictionary
            for(int i = 0; i < GameDictionary.Count; i++)
            {
                //Place all information formatted into a string.
                output += $"Name: {GameDictionary[i].Name}\n";
                output += $"Genre: {GameDictionary[i].Genre}\n";
                output += $"Maps: \n";
                foreach (string name in GameDictionary[i].MapNames)
                    output += $" - {name}\n";
                output += "\n"; //Seperate out the info.
            }


            //Output
            return output;
        }

        public List<string> MapsWithZ(GameInfo gameInfo)
        {
            List<string> namesWithZ = new List<string>();
            //Run through each info in the data
            foreach(Info info in gameInfo.MetaData)
            {//Run through all the names of the maps in the target info.
                foreach (string name in info.MapNames)
                    for (int i = 0; i < name.Length; i++) //Go through each char to see if they have a z
                        if (name[i] == 'z' || name[i] == 'Z') namesWithZ.Add(name);
            }

            return namesWithZ;
        }
    }
}
