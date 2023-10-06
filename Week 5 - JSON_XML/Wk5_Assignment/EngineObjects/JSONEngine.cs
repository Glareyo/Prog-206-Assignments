using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Wk5_Assignment.CVS_Items;
using Wk5_Assignment.JSON_Items;

namespace Wk5_Assignment.EngineObjects
{
    public class JSONEngine : Engine
    {
        public override void BeginDeciphering(IFileInformation file)
        {
            base.BeginDeciphering(file);
        }
        public override string DecipherFile(IFileInformation file)
        {
            string dataString = "";

            // Credit:
            // Leo Hazou, for providing documentation and presentation of XML file reading,
            // Code below is an exact copy of the code provided in the presentations with a few minor changes.


            // Initiate reading of the file
            using (StreamReader sr = new StreamReader(file.Path))
            {
                Student student = JsonConvert.DeserializeObject<Student>(sr.ReadToEnd());

                Console.WriteLine(student.FirstName);
                Console.WriteLine(student.LastName);
                foreach(string s in student.Address1.RetrieveFullAddress())
                    Console.WriteLine(s);

                /*
                                // Run through the produced list and create the file information
                                for (int itemNum = 0; itemNum < inventory.Items.Count; itemNum++)
                                {
                                    inventory.Items[itemNum].CreateDescription();
                                    // Go through each line
                                    //Start with which line is being read
                                    dataString += $"Line#{itemNum + 1} :";
                                    // Break line into text array from delimiter
                                    string[] text = inventory.Items[itemNum].description;

                                    //Run a loop through the split text
                                    for (int textNum = 0; textNum < text.Length; textNum++)
                                    {
                                        //Add field number and associated text
                                        dataString += $"Field#{textNum + 1}={text[textNum]}";

                                        //If it is not the last string of text, add the ==>
                                        if (textNum != text.Length - 1) dataString += " ==> ";
                                    }
                                    dataString += "\n\n";
                                }*/
            }

            return dataString;
        }
    }
}
