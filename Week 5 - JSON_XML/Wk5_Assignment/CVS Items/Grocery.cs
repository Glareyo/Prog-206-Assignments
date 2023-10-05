using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wk5_Assignment.CVS_Items
{
    [XmlRoot(ElementName = "menu")]
    internal class Grocery
    {
        public List<Item> Items { get; set; }
    }
}
