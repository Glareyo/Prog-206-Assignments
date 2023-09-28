using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk4_Assignment_StructuredTxt_CSV_Tab_Delimited
{
    public interface IFileInformation
    {
        //Base Interface that holds file information
        string Name { get; set; }
        string Path { get; set; }
        char Delimiter { get; set; }
        string FileType { get; set; }
    }
}
