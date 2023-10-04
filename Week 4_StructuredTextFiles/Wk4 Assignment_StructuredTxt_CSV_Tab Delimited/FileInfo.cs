using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk4_Assignment_StructuredTxt_CSV_Tab_Delimited
{
    // Class that creates the file objects
    public class FileInfo : IFileInformation
    {
        const char PIPE = '|';
        const char COMMA = ',';


        public string Name { get; set; }
        public string Path { get; set; }
        public char Delimiter { get; set; }
        public string FileType { get; set; }

        public string DecipheredData { get; set; }

        //Constructor
        public FileInfo(string _name, string _path, DataHandler.DelimiterTypes _delimiter, DataHandler.FileTypes _fileType)
        {
            Name = _name;
            Path = _path;

            //Determine Delimiter
            if (_delimiter == DataHandler.DelimiterTypes.pipe)
            {
                Delimiter = PIPE;
            }
            else
            {
                Delimiter = COMMA;
            }

            //Determine File Type
            if (_fileType == DataHandler.FileTypes.csv)
            {
                FileType = ".csv";
            }
            else
            {
                FileType = ".txt";
            }

        }
    }
}
