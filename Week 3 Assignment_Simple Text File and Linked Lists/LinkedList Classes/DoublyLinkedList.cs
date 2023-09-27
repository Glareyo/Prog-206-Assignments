using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week_3_Assignment_Simple_Text_File_and_Linked_Lists.LinkedList_Classes
{
    public class DoublyLinkedList
    {
        private string dataDirectory = "../../GameResultsData/GameResults.txt";

        string name; public string Name { get { return this.name; } }

        List<Node> nodes; public List<Node> Nodes { get { return this.nodes; } }

        Node head; public Node Head { get { return this.head; } }
        Node tail; public Node Tail { get { return this.tail; } }

        public DoublyLinkedList(string _name)
        {
            this.name = _name;
            this.nodes = new List<Node>();
        }
        public void UpdateNodeLinks()
        {
            if (nodes.Count > 0)
            {
                head = nodes.First();
                tail = nodes.Last();
                //Start on node 2 if applicable, but end before last node.
                for(int index = 1; index < nodes.Count-1; index++)
                {
                    Node target = nodes[index];
                    target.PreviousNode = nodes[index - 1];
                    target.NextNode = nodes[index + 1];
                }
            }
        }

        public void AddNode(string name, string info)
        {
            Node node = new Node(name, info);
            nodes.Add(node);
            UpdateNodeLinks();
        }
        public void AddNode(string name, string info, Node targetNode, bool placeBeforeNode)
        {
            Node node = new Node(name, info);
            int pos = NodePosition(targetNode);

            if (placeBeforeNode)
                //Get the position of the target node
                nodes.Insert(pos, node);
            else nodes.Insert(pos + 1, node);

            UpdateNodeLinks();
        }

        public int NodePosition(Node targetNode)
        {
            int location = 0;
            for(int index = 0; index < nodes.Count; index++)
                if (nodes[index] == targetNode) location = index;
            return location;
        }
        public Node SearchNode(string name)
        {
            foreach (Node node in nodes)
                if (node.Name == name) return node;
            throw new Exception("Node not Found");
        }
        public void PrintResults()
        {
            List<string> results = new List<string>();
            foreach(Node node in nodes)
            {
                results.Add(node.Name);
                results.Add(node.Information);
                results.Add("");
            }

            File.WriteAllLines(dataDirectory, results);
        }
    }
}
