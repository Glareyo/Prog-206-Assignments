using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Week_3_Assignment_Simple_Text_File_and_Linked_Lists
{
    public class Room
    {
        //Basic Information of Room
        int id;
        string name;
        string description;

        //Adjacent Rooms
        private int[] adjRooms;


        //Items in room
        public List<Item> loot = new List<Item>();


        //Encapsulation so that the information does not change.
        public int GetID { get { return id; } }
        public string GetDescription { get { return description; } }
        public string GetName { get { return name; } }

        public Room(int _id, string _name, string _description, int[] _adjRoomIDs)
        {
            this.id = _id;
            this.name = _name;
            this.description = _description;

            adjRooms = _adjRoomIDs;
        }
        
        public int GiveAdjRoomID(UIUtility.Directions dir)
        {
            return adjRooms[(int)dir];
        }
        public int[] AdjacentRoomsIDs { get { return adjRooms; } }
    }
}
