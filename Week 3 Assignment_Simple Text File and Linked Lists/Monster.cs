using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_Assignment_Simple_Text_File_and_Linked_Lists
{
    public class Monster
    {
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int HP;
        public int MP { get; set; }
        public int AP { get; set; }
        public int DEF { get; set; }

        public Monster(string _name, int _hP, int _mP, int _aP, int _dEF)
        {
            Name = _name;
            MaxHP = _hP;
            HP = _hP;
            MP = _mP;
            AP = _aP;
            DEF = _dEF;
        }
    }
}
