using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Wk5_Assignment.CVS_Items;

namespace Wk5_Assignment.EngineObjects
{
    /// <summary>
    /// Engine designed to take in XML Data
    /// </summary>
    public class XMLEngine : Engine
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
            using (var fs = File.Open(file.Path,FileMode.Open))
            {
                // XmlSerilizer ==> Basically not sure what it does.
                // Code will target the grocery object, in which grocery begins with the root of menu.
                XmlSerializer s = new XmlSerializer(typeof(Grocery));

                // Inventory then acts as an object, instantiating a grocery
                // Deserialize pretty much reads through each root/line and creates the items.
                var inventory = (Grocery)s?.Deserialize(fs);
                

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
                }
            }

            return dataString;
        }
    }
}
