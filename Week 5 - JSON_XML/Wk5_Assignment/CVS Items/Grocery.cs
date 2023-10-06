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

    // Main target for reading data
    [XmlRoot(ElementName = "menu")]
    public class Grocery
    {
        //Target for the items
        [XmlElement(ElementName = "item")]
        public List<Item> Items { get; set; }

        public void CreateItemDescriptions()
        {
            foreach(Item item in Items)
            {
                item.CreateDescription();
            }
        }
    }
}
