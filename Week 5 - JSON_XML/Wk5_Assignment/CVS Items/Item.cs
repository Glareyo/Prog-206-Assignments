using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wk5_Assignment.CVS_Items
{
    // Credit:
    // Leo Hazou, for providing documentation and presentation of XML file reading,
    // Code below is an exact copy of the code provided in the presentations.

    // Main target for reading an XML Document
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        // Created through constructor
        public string[] description { get; set; }

        // XML element that this variable will read and store from.
        [XmlElement(ElementName = "name")] 
        public string name { get; set; }

        // XML element that this variable will read and store from.
        [XmlElement(ElementName = "price")]
        public string price { get; set; }

        // XML element that this variable will read and store from.
        [XmlElement(ElementName = "uom")]
        public string uom { get; set; }

        // Seperate for publishing purposes
        public void CreateDescription()
        {
            string[] des = { name,price,uom};
            description = des;
        }
    }
}
