using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5_Assignment
{
    public interface IFileInformation
    {
        //Base Interface that holds file information
        string Name { get; set; }
        string Path { get; set; }
        char Delimiter { get; set; }
        DataHandler.FileTypes FileType { get; set; }
        string DecipheredData { get; set; }
    }
}
