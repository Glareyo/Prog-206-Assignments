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

                for(int position = 0; position < strings.Length; position++)
                {
                    //Check to see if the string contains '
                    if (strings[position].Contains('\''))
                    {
                        string replacement = "";
                        foreach(char character in strings[position])
                        {
                            if (character == '\'')
                            {
                                replacement += character;
                            }
                            replacement += character;
                        }
                        strings[position] = replacement;
                    }


                    incomingData.Add(strings[position]);
                }
                file.Data.Add(incomingData);
            }
            file.Data.RemoveAt(0);
        }
    }
}
