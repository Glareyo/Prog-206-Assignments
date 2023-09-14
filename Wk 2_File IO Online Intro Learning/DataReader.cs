using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk_2_File_IO_Online_Intro_Learning
{
    public class DataReader
    {
        public void InitiateFileRead()
        {
            //Directory of files
            string dir = "../../data";
            //Get all file names for reading
            string[] fileNames = Directory.GetFiles(dir);

            //Read Each file
            foreach (string name in fileNames)
            {//Set file data to strings
                string file = new FileInfo(name).Name;
                string text = File.ReadAllText(name).ToLower();

                //Create a new dictionary
                Dictionary<char, int> d = CreateDictionary();

                //Read through each char of the text.
                //Add them to the value of the matching key.
                foreach (char c in text)
                    if (d.ContainsKey(c)) d[c] += 1;

                //Print Data
                PrintData(file, d);
            }
        }


        //Print the strings
        void PrintData(string name, Dictionary<char, int> dictionary)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("File: " + name);

            Console.ForegroundColor = ConsoleColor.White;
            foreach (var key in dictionary)
                Console.WriteLine($"  {key.Key} : {key.Value}");

            Console.WriteLine();
            Console.ResetColor();
        }

        Dictionary<char,int> CreateDictionary()
        {
            //Alphabet
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            //Create a new dictionary
            foreach(char c in alphabet)
                dictionary.Add(c, 0);
        
            return dictionary;
        }

    }
}
