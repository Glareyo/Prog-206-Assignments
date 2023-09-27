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
        private string dataDirectory = "../../data";

        private List<Item> allItems; public List<Item> AllItems { get { return allItems; } }
        private List<Room> allRooms; public List<Room> AllRooms { get { return allRooms; } }


        public void InitDataCreation()
        {
            allRooms = CreateRooms(dataDirectory,"Room_Data", "Room-data/Room");
            allItems = CreateItems(dataDirectory, "Item_Data", "Item-data/Item",AllRooms);

        }
        public Room FindRoom(int id, List<Room> targetList)
        {
            foreach(Room room in targetList)
                if (room.GetID == id) return room;

            throw new Exception("No Room Found");
        }
        
        public List<Room> CreateRooms(string dataDirectory, string file, string root)
        {
            List<Room> rooms = new List<Room>();

            foreach (XmlElement i in GetList(dataDirectory, file, root))
            {
                int id = Convert.ToInt32(text(i,0));
                string name = text(i,1);
                string des = text(i, 2);
                int[] adjIDs =
                {
                    Convert.ToInt32(text(i,3)),
                    Convert.ToInt32(text(i,4)),
                    Convert.ToInt32(text(i,5)),
                    Convert.ToInt32(text(i,6))
                };
                rooms.Add(new Room(id, name, des, adjIDs));
            }
            return rooms;
        }
        public List<Item> CreateItems(string dataDirectory, string file, string root,List<Room> lootLocations)
        {
            List<Item> items = new List<Item>();

            foreach (XmlElement i in GetList(dataDirectory, file, root))
            {
                string name = text(i, 0);
                string des = text(i, 1);
                int dmg = Convert.ToInt32(text(i, 2));
                int targetRoom = Convert.ToInt32(text(i, 3));

                Item tempItem = new Item(name, des, dmg);
                items.Add(tempItem);

                FindRoom(targetRoom, lootLocations).loot.Add(tempItem);
            }
            return items;
        }


        //Private voids Used only in the data handler
        private string text(XmlElement element,int index)
        {
            return (element.ChildNodes[index].InnerText);
        }
        XmlNodeList GetList(string dataDirectory, string file, string rootName)
        {//This searches for the file that the data can be found it for instantiating items.

            XmlDocument doc = new XmlDocument();
            doc.Load($"{dataDirectory}/{file}.xml"); //Load the document

            XmlNode root = doc.DocumentElement;
            //return the root so that the methods can read off the information
            return root.SelectNodes($"/{rootName}");
        }
    }
}
