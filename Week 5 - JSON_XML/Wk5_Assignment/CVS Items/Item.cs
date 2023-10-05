using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wk5_Assignment.CVS_Items
{
    [XmlRoot(ElementName = "item")]
    internal class Item
    {
        [XmlElement(ElementName = "name")]
        string name;
        [XmlElement(ElementName = "price")]
        string price;
        [XmlElement(ElementName = "uom")]
        string uom;
    }
}
