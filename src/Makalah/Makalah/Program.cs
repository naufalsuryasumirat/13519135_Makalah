using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makalah
{
    class Program
    {
        static void Main(string[] args)
        {
            //Graph g = new Graph();
            //Node node1 = new Node("node1", 222.0, 223.0);
            //Node node2 = new Node("node2", 222.0, 223.0);
            //Node node3 = new Node("node3", 222.0, 223.0);
            //Node node4 = new Node("node4", 222.0, 223.0);
            //Node node5 = new Node("node5", 222.0, 223.0);
            //g.AddNode(node1);
            //g.AddNode(node2);
            //g.AddNode(node3);
            //g.AddNode(node4);
            //g.AddNode(node5);
            //g.SelectRandom("node1", "node2");
            //g.AStar("node1", "node2");
            // Random rand = new Random();
            FileHandler file = new FileHandler("../../../../../test/connections.txt");
            Graph graph = file.GetGraph();
            // graph.PrintInfo();
            graph.AStar("Indonesia", "Singapore");
        }
    }
}
