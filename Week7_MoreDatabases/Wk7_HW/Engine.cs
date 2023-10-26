using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk7_HW
{
    /// <summary>
    /// Used to parse files
    /// </summary>
    public class Engine
    {

        /// <summary>
        /// Take in the fileType
        /// </summary>
        /// <returns></returns>
        public void DecipherFileData(List<IFileInformation> list)
        {
            string[] retrievedData = new string[list.Count];
            //Run through each file on the list
            foreach(IFileInformation file in list)
            {
                DecipherFile(file);
            }
        }

        /// <summary>
        /// Breaks the target file into a readable state
        /// </summary>
        /// <returns>String</returns>
        public void DecipherFile(IFileInformation file)
        {
            string[] dataLines = File.ReadAllLines(file.Path);
            
            foreach (string line in dataLines)
            {
                List<string> incomingData = new List<string>();

                //Split the data up into an array
                string[] strings = line.Split(file.Delimiter);

                //Arrays for settings types
                string[] types = { "Ghost", "Human", "Melee Island", "Inmate", "Pirate", "NPC", "Mighty Pirate", "Politician", "Ghost Pirate", "Ghost Cook", "Fire Ghost" };
                string[] locations = { "Melee Island", "Terror Island", "Brrrmuda", "Scurvy Island", "LeChuck's ship" };

                



                for (int position = 0; position < strings.Length; position++)
                {
                    //Trim spaces from start since 
                    strings[position] = strings[position].TrimStart();

                    //Check types to convert to IDs
                    for (int index = 0; index < locations.Length; index++)
                    {
                        if (locations[index] == strings[position])
                        {
                            strings[position] = $"{index + 1}";
                        }
                    }

                    for (int target = 0; target < types.Length; target++)
                    {
                        if (types[target] == strings[position])
                        {
                            strings[position] = $"{target + 1}";
                        }
                    }


                    incomingData.Add(strings[position]);
                }
                
                
                
                file.Data.Add(incomingData);
            }
            file.Data.RemoveAt(0);
        }
    }
}
