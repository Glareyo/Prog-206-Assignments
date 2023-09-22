﻿using System;
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
        int nRoomID;
        int sRoomID;
        int eRoomID;
        int wRoomID;

        //Items in room
        public List<Item> loot = new List<Item>();


        //Encapsulation so that the information does not change.
        public int GetID { get { return id; } }
        public string GetDescription { get { return description; } }
        public string GetName { get { return name; } }
        public int GetNRoomID { get { return nRoomID; } }
        public int GetSRoomID { get { return sRoomID; } }
        public int GetERoomID { get { return eRoomID; } }
        public int GetWRoomID { get { return wRoomID; } }



        //Give all room IDs via N,S,E,W
        public int[] GetAdjRoomIDs { get { return new int[] { nRoomID,sRoomID,eRoomID,wRoomID}; } }
        
        public Room(int _id, string _name, string _description, int _nRoomID, int _sRoomID, int _eRoomID, int _wRoomID)
        {
            this.id = _id;
            this.name = _name;
            this.description = _description;
            this.nRoomID = _nRoomID;
            this.sRoomID = _sRoomID;
            this.eRoomID = _eRoomID;
            this.wRoomID = _wRoomID;
        }
        
    }
}
