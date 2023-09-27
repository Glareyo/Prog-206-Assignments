using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Week_3_Assignment_Simple_Text_File_and_Linked_Lists
{
    public class Player
    {
        //Basic Info on player
        private string name; public string Name { get { return this.name; } } //Name
        public int lives = 3; //Num of lives.

        //Location of the player
        private Room loc; public Room Location { get { return this.loc; } }

        //Inventory
        private List<Item> inv; public List<Item> Inventory { get { return this.inv; } }

        public Player(string _name, Room _loc)
        {
            this.name = _name;
            this.loc = _loc;
            this.inv = new List<Item>();
        }

        public string Move(Room targetRoom)
        {
            loc = targetRoom;
            return $"Player in {targetRoom.GetName}";
        }
    }
}
