using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Makalah
{
    class FileHandler
    {
        private List<Node> nodelist;
        private Graph graph;
        public FileHandler()
        {
            this.graph = new Graph();
            this.nodelist = new List<Node>();
        }
        public FileHandler(string path)
        {
            this.nodelist = new List<Node>();
            string line;
            var readFile = new StreamReader(path);
            line = readFile.ReadLine();
            while (line != null)
            {
                var arr = line.Split(new[] { ' ' });
                double latitude = double.Parse(arr[1], CultureInfo.InvariantCulture);
                double longitude = double.Parse(arr[2], CultureInfo.InvariantCulture);
                this.nodelist.Add(new Node(arr[0], latitude, longitude));
                line = readFile.ReadLine();
            }
            this.graph = new Graph(this.nodelist);
            readFile.Close();
        }
        public Graph GetGraph()
        {
            return this.graph;
        }
    }
}
