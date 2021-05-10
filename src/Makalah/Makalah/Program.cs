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
            FileHandler file = new FileHandler("../../../../../test/connections.txt");
            Graph graph = file.GetGraph();
            graph.AStar("Indonesia", "Singapore"); // Fixed Start and Goal
            //graph.AStarRand(); // Random Start and Goal
            string end = Console.ReadLine();
        }
    }
}
