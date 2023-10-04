using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wk4_Assignment_StructuredTxt_CSV_Tab_Delimited
{
    //Handles reading data
    public class DataHandler
    {
        public enum FileTypes { csv, txt }
        public enum DelimiterTypes { pipe, comma }


        public List<IFileInformation> allFiles {get; set;}

        // Path that leads to all the required files
        string folderPath = Directory.GetCurrentDirectory();

        //Constructor
        //Used mainly for unit testing
        public DataHandler() 
        {
            folderPath +=@"..\..\..\Files";
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
            //Seperate the files based on file types
           allFiles = GetTargetFiles();

            
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
    }
}
