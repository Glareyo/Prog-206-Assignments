using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Using text files for reading
using System.IO;

namespace Week_4_DemoEngine
{
    internal class Program
    {
        /// <summary>
        /// An in-class demo of reading a structured text file
        /// </summary>
        static void Main(string[] args)
        {
            //Get the directory of the target files
            var path = Directory.GetCurrentDirectory() + @"..\..\..\Files\demo.txt";
                                                       //"\\Files\\demo.txt"; ==> Option 2

            //Opening a new stream to read the files based on the intended path
            using(StreamReader sr = new StreamReader(path))
            {
                // A new StreamReader object is created targeting the files in the path
                var line = sr.ReadLine(); //Begins reading each line of the text file and saving it to a variable

                //Run a loop while the var line has some string
                while (line != null)
                {
                    //Creates a string[] where the line read from the text file
                    //Splits a string based on the intended char. In this case ==> '|'
                    var stat = line.Split('|');
                    //Example:
                    // string test = "Hello|World";
                    // var stat = line.Split('|');
                    // stat[0] = "Hello";
                    // stat[1] = "World";

                    foreach(var item in stat)
                    {
                        Console.Write(item + " ");
                    }

                    line = sr.ReadLine(); //Read next line
                }
            }

            Console.ReadLine();
        }
    }
}
