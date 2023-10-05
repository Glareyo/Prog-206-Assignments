using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5_Assignment
{
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
