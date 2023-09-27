using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_Assignment_Simple_Text_File_and_Linked_Lists
{
    public class Item
    {
        //Item class
        private string name; public string Name { get { return name; } }
        string description; public string Description { get { return description; } }
        int damage; public int Damage { get { return damage; } }
        

        public Item(string _name, string _description,int _damage)
        {
            this.name = _name;
            this.description = _description;
            this.damage = _damage;
        }
    }
}
