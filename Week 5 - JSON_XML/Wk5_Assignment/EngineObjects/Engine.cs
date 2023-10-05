using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5_Assignment
{
    /// <summary>
    /// Used to parse files
    /// Base engine for other engines
    /// </summary>
    public abstract class Engine
    {
        /// <summary>
        /// Take in the fileType
        /// </summary>
        /// <returns></returns>
        public virtual void BeginDeciphering(IFileInformation file)
        {
             file.DecipheredData = DecipherFile(file);
        }

        /// <summary>
        /// Breaks the target file into a readable state
        /// </summary>
        /// <returns>String</returns>
        public virtual string DecipherFile(IFileInformation file)
        {
            string dataString = "";
            string[] dataLines = File.ReadAllLines(file.Path);

            // Go through each line
            for(int lineNum = 0; lineNum < dataLines.Length; lineNum++)
            {
                //Start with which line is being read
                dataString += $"Line#{lineNum + 1} :";
                // Break line into text array from delimiter
                string[] text = dataLines[lineNum].Split(file.Delimiter);

                //Run a loop through the split text
                for(int textNum = 0; textNum < text.Length;textNum++)
                {
                    //Add field number and associated text
                    dataString += $"Field#{textNum + 1}={text[textNum]}";

                    //If it is not the last string of text, add the ==>
                    if (textNum != text.Length - 1) dataString += " ==> ";
                }
                dataString += "\n\n";
            }

            return dataString;
        }
    }
}
