using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk6_HW
{
    public interface IFileInformation
    {
        //Base Interface that holds file information
        string Name { get; set; }
        string Path { get; set; }
        char Delimiter { get; set; }
        string FileType { get; set; }
        string DecipheredData { get; set; }
    }
}
