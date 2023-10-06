using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Wk5_Assignment.EngineObjects;

namespace Wk5_Assignment
{
    //Handles reading data
    public class DataHandler
    {
        // Enums for assigning file types
        public enum FileTypes { csv, txt,json,xml }
        public enum DelimiterTypes { pipe, comma,none }

        // Holds all files
        public List<IFileInformation> allFiles {get; set;}



        // Path that leads to all the required files
        string folderPath = Directory.GetCurrentDirectory();
        string resultsFolderPath = Directory.GetCurrentDirectory();

        

        //Constructor
        //Used mainly for unit testing
        public DataHandler() 
        {
            folderPath +=@"..\..\..\Files";
            resultsFolderPath = folderPath + @"\Results";
        }
        public DataHandler(string targetFilePath)
        {
            folderPath += targetFilePath;
            resultsFolderPath = folderPath + @"\Results";
        }

        /// <summary>
        /// Get the files from the designated file path.
        /// </summary>
        public void InitDataCreation()
        {
            //Seperate the files based on file types
            allFiles = GetTargetFiles();

            //Decipher each file
            foreach(IFileInformation file in allFiles)
            {
                // Engine that'll take in all target files and get the data
                Engine engine;

                switch (file.FileType)
                {
                    case FileTypes.txt:
                        engine = new PipeEngine();
                        engine.BeginDeciphering(file);
                        break;
                    case FileTypes.csv:
                        engine = new CVSEngine();
                        engine.BeginDeciphering(file);
                        break;
                    case FileTypes.json:
                        engine = new JSONEngine();
                        engine.BeginDeciphering(file);
                        break;
                    case FileTypes.xml:
                        engine = new XMLEngine();
                        engine.BeginDeciphering(file);
                        break;
                }
                
                
            }

            //Publish the file
            PublishIntoFiles();
        }


        /// <summary>
        /// Publish the gathered information into associated files
        /// </summary>
        public void PublishIntoFiles()
        {
            //Go through each file
            foreach(IFileInformation file in allFiles)
            {
                string name = "Sample";
                
                //Determine how to name the file
                switch(file.FileType)
                {
                    case FileTypes.csv:
                        name += "CSV";
                        break;
                    case FileTypes.txt:
                        name += "Pipe";
                        break;
                    case FileTypes.json:
                        name += "JSON";
                        break;
                    case FileTypes.xml:
                        name += "XML";
                        break;
                }
                name += "_out.txt";

                //Create a new text file in the target folder path with the new name.
                string tempPath = Path.Combine(resultsFolderPath, name);
                File.WriteAllText(tempPath,file.DecipheredData);
            }
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
                if (!file.Contains("_out"))
                {
                    //Needs a name, path, delimiter, and fileType
                    FileInfo newFile = null;

                    // Name the file
                    // Get the path of the file.
                    string name = file.Substring(file.LastIndexOf('\\') + 1);
                    string path = file;

                    if (file.Contains($".{FileTypes.csv}"))
                    {// If it is a CSV, store as a CSV with a comma
                        newFile = new FileInfo(name, path, DelimiterTypes.comma, FileTypes.csv);
                    }
                    else if (file.Contains($".{FileTypes.txt}"))
                    {// If a TXT, store as txt with |
                        newFile = new FileInfo(name, path, DelimiterTypes.pipe, FileTypes.txt);
                    }
                    else if (file.Contains($".{FileTypes.json}"))
                    {// If a JSON, store as JSON with no Delimiter
                        newFile = new FileInfo(name, path, DelimiterTypes.none, FileTypes.json);
                    }
                    else if (file.Contains($".{FileTypes.xml}"))
                    {// If a XML, store as JSON with no Delimiter
                        newFile = new FileInfo(name, path, DelimiterTypes.none, FileTypes.xml);
                    }

                    //Add to file class
                    allFiles.Add(newFile);
                }
            }

            //Return new file list
            return allFiles;
        }
    }
}
