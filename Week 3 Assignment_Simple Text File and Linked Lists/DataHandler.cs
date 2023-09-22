using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Week_3_Assignment_Simple_Text_File_and_Linked_Lists
{
    public class DataHandler
    {
        string dataPath = "../../data";



        /*void CreateItems()
        {
            string file = "Item_Data";
            string root = "Item-data/Item";

            foreach (XmlElement i in GetList(file, root))
            {
                string n = i.ChildNodes[0].InnerText;
                string d = i.ChildNodes[1].InnerText;
                int location = Convert.ToInt32(i.ChildNodes[2].InnerText);

                Item temp = new Item(n, d);
                allItems.Add(temp);
                allRooms[location].loot.Add(temp);
            }
        }
        XmlNodeList GetList(string file, string rootName)
        {//This searches for the file that the data can be found it for instantiating items.

            XmlDocument doc = new XmlDocument();
            doc.Load($"../../data/{file}.xml"); //Load the document

            XmlNode root = doc.DocumentElement;
            //return the root so that the methods can read off the information
            return root.SelectNodes($"/{rootName}");
        }*/
    }
}
