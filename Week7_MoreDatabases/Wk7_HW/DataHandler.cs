using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wk7_HW
{
    //Handles reading data
    public class DataHandler
    {
        // Enums for assigning file types
        public enum FileTypes { csv, txt }
        public enum DelimiterTypes { pipe, comma }

        //Arrays for settings types
        string[] types = { "Ghost", "Human", "Melee Island","Inmate","Pirate","NPC","Mighty Pirate","Politician","Ghost Pirate","Ghost Cook","Fire Ghost"};
        string[] locations = { "Melee Island","Terror Island", "Brrrmuda","Scurvy Island","LeChuck''s Ship" };

        // Holds all files
        public List<IFileInformation> allFiles { get; set; }
        public List<IFileInformation> CSVFiles = new List<IFileInformation>();
        public List<IFileInformation> TXTFiles = new List<IFileInformation>();


        // Engine that'll take in all target files and get the data
        Engine engine;

        // Path that leads to all the required files
        string folderPath = Directory.GetCurrentDirectory();



        //Constructor
        //Used mainly for unit testing
        public DataHandler()
        {
            folderPath += @"..\..\..\..\data";
        }
        public DataHandler(string targetFilePath)
        {
            folderPath += targetFilePath;
        }

        /// <summary>
        /// Get the files from the designated file path.
        /// </summary>
        public void InitDataCreation()
        {
            engine = new Engine();
            //Seperate the files based on file types
            allFiles = GetTargetFiles();

            //Seperate based on file type

            CSVFiles = new List<IFileInformation>();
            TXTFiles = new List<IFileInformation>();

            foreach (IFileInformation file in allFiles)
            {
                if (file.FileType == ".txt")
                {
                    TXTFiles.Add(file);
                }
                else if (file.FileType == ".csv")
                {
                    CSVFiles.Add(file);
                }
            }
            // Decipher txt files
            engine.DecipherFileData(TXTFiles);
            // Decipher csv files
            engine.DecipherFileData(CSVFiles);

            //SetIDs();
        }

        /// <summary>
        /// Create all the target files.
        /// </summary>
        /// <returns></returns>
        public List<IFileInformation> GetTargetFiles()
        {
            List<IFileInformation> allFiles = new List<IFileInformation>();
            //Seperate the files based on file types, filter out other files.
            foreach (string file in Directory.GetFiles(folderPath))
            {
                //Filter out files with "_out". These are output files
                if (!file.Contains("_out") && !file.Contains(".sql"))
                {
                    //Needs a name, path, delimiter, and fileType
                    FileInfo newFile;

                    // Name the file
                    // Get the path of the file.
                    string name = file.Substring(file.LastIndexOf('\\') + 1);
                    string path = file;

                    if (file.Contains(".csv"))
                    {// If it is a CSV, store as a CSV with a comma
                        newFile = new FileInfo(name, path, DelimiterTypes.comma, FileTypes.csv);
                    }
                    else
                    {// If a TXT, store as txt with |
                        newFile = new FileInfo(name, path, DelimiterTypes.pipe, FileTypes.txt);
                    }

                    //Add to file class
                    allFiles.Add(newFile);
                }
            }

            //Return new file list
            return allFiles;
        }


        /// <summary>
        /// Sets the IDs of the information that can be gathered in another table
        /// </summary>
        void SetIDs()
        {
            //([Character],[Type],[Map_Location],[Original_charachter],[Sword_Fighter],[Magic_User])";
            //('{item[0]}','{item[1]}','{item[2]}','{item[3]}','{item[4]}','{item[5]}')";
            Console.WriteLine("\n\n\n\nTargeting IDs");

            foreach(List<string> info in CSVFiles[0].Data)
            {
                Console.Write(info[0]+":");
                //Check to see what the type matches to
                for(int index = 0; index < locations.Length; index++)
                {
                    if (locations[index].ToLower() == info[2].ToLower())
                    {
                        
                        info[2] = $"{index+1}";
                    }
                }

                Console.WriteLine($" => {info[1].ToLower()}");
                for(int index = 0; index < types.Length; index++)
                {
                    Console.WriteLine($" => Comparing to {types[index].ToLower()}");
                    if (types[index].ToLower() == info[1].ToLower())
                    {
                        Console.WriteLine($"Changing {info[1]} to {index + 1}");
                        info[1] = $"{index+1}";
                    }
                }
            }
        }
    }
}
