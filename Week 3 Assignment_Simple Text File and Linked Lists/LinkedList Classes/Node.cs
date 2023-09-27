using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_Assignment_Simple_Text_File_and_Linked_Lists.LinkedList_Classes
{
    public class Node
    {
        //Previous Node
        public Node PreviousNode { get; set; }
        //Next Node
        public Node NextNode { get; set; }
        //Inner Information
        string name; public string Name { get { return name; } }
        string info; public string Information { get { return info; } }

        public Node(string _name,string _info)
        {
            this.name = _name;
            this.info = _info;

            PreviousNode = null;
            NextNode = null;
        }
        public Node(string _name, string _info, Node _targetNode,bool placeBeforeNode)
        {
            this.name = _name;
            this.info = _info;
            Node node = _targetNode;
            if (placeBeforeNode)
                NextNode = node;
            else
                PreviousNode = node;
        }
        public Node(string _name, string _info,Node _PreviousNode,Node _NextNode)
        {
            this.name = _name;
            this.info = _info;
            this.PreviousNode = _PreviousNode;
            this.NextNode = _NextNode;
        }
    }
}
