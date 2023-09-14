using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wk_2_File_IO_Online_Intro_Learning
{
    internal class Program
    {
        //Credits
        //Text used in text files were
        //exerpts from the Prog 260-01 C# Fundementals Guide.
        static void Main(string[] args)
        {
            //DataReader used to read in data.
            DataReader data = new DataReader();
            data.InitiateFileRead();

            Console.ReadLine();
        }
    }
}
