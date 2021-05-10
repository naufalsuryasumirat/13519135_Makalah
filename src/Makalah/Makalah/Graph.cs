using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makalah
{
    class Graph
    {
        private List<Node> nodes;
        public Graph()
        {
            this.nodes = new List<Node>();
        }
        public Graph(List<Node> nodes)
        {
            this.nodes = nodes;
        }
        public List<Node> GetNodes()
        {
            return this.nodes;
        }
        public void AddNode(Node node)
        {
            this.nodes.Add(node);
        }
        public void PrintInfo()
        {
            Console.WriteLine("Printing Graph Info");
            foreach (var node in this.nodes)
            {
                node.PrintInfo();
            }
        }
        public Node findNode(string name)
        {
            foreach (Node node in this.nodes)
            {
                if (node.GetName() == name) return node;
            }
            return null;
        }
        public List<Node> SelectRandom(string from, string to) // Exclude node from and to
        {
            if (this.nodes.Count < 5) { Console.WriteLine("Not enough nodes"); return null; }
            List<Node> copy = new List<Node>(this.nodes);
            foreach (var node in this.nodes.ToList())
            {
                if (node.GetName().Equals(from) || node.GetName().Equals(to)) copy.Remove(node);
            }
            List<int> randomized = new List<int>();
            Random rand = new Random();
            int number;
            int size = (this.nodes.Count / 2) + 1;
            if (size > 10) size = 10;
            for (int i = 0; i < size; i++)
            {
                do {
                    number = rand.Next(0, copy.Count);
                } while (randomized.Contains(number));
                randomized.Add(number);
            }
            List<Node> toReturn = new List<Node>();
            foreach (int index in randomized) toReturn.Add(copy[index]);
            Console.WriteLine("Randomized selected nodes:");
            foreach (var node in toReturn) node.Print();
            return toReturn;
        }
        public void AStar(string from, string to)
        {
            Node StartNode = this.findNode(from);
            Node GoalNode = this.findNode(to);
            List<Node> selected = this.SelectRandom(from, to);
            if (selected == null) return;
            List<Tuple<List<Node>, double, double>> PQueue = new List<Tuple<List<Node>, double, double>>();
            Console.WriteLine("Finding connection from " + from + " to " + to);
            List<Node> first = new List<Node>();
            first.Add(StartNode);
            PQueue.Add(new Tuple<List<Node>, double, double>(first, 0, StartNode.CalcPing(GoalNode)));
            while (PQueue.Count > 0)
            {
                var Head = PQueue[0]; // Head of PQueue
                PQueue.RemoveAt(0); // Popping Head
                if (Head.Item1.Count == 5) // Shortest Path
                {
                    Console.WriteLine("Found path connection:");
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write(Head.Item1[i].GetName());
                        if (i != 4) Console.Write(" ←→ ");
                        else Console.WriteLine(".");
                    }
                    Console.WriteLine("Cost: " + Head.Item2);
                    PQueue.Clear();
                    return;
                }
                else
                {
                    if (Head.Item1.Count == 4)
                    {
                        List<Node> toAdd = new List<Node>(Head.Item1) { GoalNode };
                        double pingDis = Head.Item2 + Head.Item1.Last().CalcPing(GoalNode);
                        PQueue.Add(new Tuple<List<Node>, double, double>(toAdd, pingDis, pingDis));
                    }
                    else
                    {
                        var leastPing = new Tuple<Node, double>(null, 0.0);
                        foreach (var node in selected)
                        {
                            if (Head.Item1.Contains(node)) continue; // Already in path, continue
                            if (leastPing.Item1 == null)
                            {
                                leastPing = new Tuple<Node, double>(node, Head.Item1.Last().CalcPing(node));
                            }
                            else
                            {
                                var ping = Head.Item1.Last().CalcPing(node);
                                if (ping < leastPing.Item2) leastPing = new Tuple<Node, double>(node, ping);
                            }
                        }
                        List<Node> toAdd = new List<Node>(Head.Item1) { leastPing.Item1 };
                        PQueue.Add(new Tuple<List<Node>, double, double>
                            (toAdd, Head.Item2 + leastPing.Item2, Head.Item2 + leastPing.Item2 + Head.Item1.Last().CalcPing(GoalNode)));
                    }
                    PQueue.Sort((x, y) => x.Item3.CompareTo(y.Item3));
                }
            }
            return;
        }
    }
}
