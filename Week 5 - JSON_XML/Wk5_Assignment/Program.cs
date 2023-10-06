using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5_Assignment
{
    // Credit:
    // Leo Hazou, for providing documentation and presentation of XML file reading,
    // Code below is an exact copy of the code provided in the presentations.
    internal class Program
    {
        static void Main(string[] args)
        {
            DataHandler d = new DataHandler();
            d.InitDataCreation();
            Console.WriteLine("WOrked");

            Console.ReadLine();
        }
    }
}
