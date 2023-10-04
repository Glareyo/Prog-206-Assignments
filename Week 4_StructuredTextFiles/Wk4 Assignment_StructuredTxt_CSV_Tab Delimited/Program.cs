using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk4_Assignment_StructuredTxt_CSV_Tab_Delimited
{
    internal class Program
    {
        //Read the provided SampleCSV.csv and SamplePipe.txt
        //and output them to a file in the same directory in the format filename_out.txt with the context formatted
        //like the provided SamplePipe_out.txt and SampleCSV_out.txt

        static void Main(string[] args)
        {
            DataHandler data = new DataHandler();
            data.InitDataCreation();

            /*foreach(var file in data.allFiles)
            {
                Console.WriteLine(file.Name);
            }*/

            foreach(var file in data.TXTFiles)
            {
                Console.WriteLine(file.DecipheredData);
            }

            Console.WriteLine("\n");

            foreach (var file in data.CSVFiles)
            {
                Console.WriteLine(file.DecipheredData);
            }

            Console.ReadLine();
        }
    }
}
