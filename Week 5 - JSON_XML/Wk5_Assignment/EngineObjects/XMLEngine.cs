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
            using (var fs = File.Open(file.Path,FileMode.Open))
            {
                XmlSerializer s = new XmlSerializer(typeof(Grocery));
                var inventory = (Grocery)s?.Deserialize(fs);

                // Run through the produced list and create the file information
                //for (int itemNum = 0; itemNum < inventory.Items.Count)

            }


            return base.DecipherFile(file);
        }
    }
}
