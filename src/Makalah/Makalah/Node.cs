using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makalah
{
    class Node
    {
        const int LIGHT = 299792458; // Kecepatan cahaya dalam meter/s
        private string Name; // Nama node
        private Tuple<double, double> Coordinate; // Koordinat Node (Latitude, Longitude)
        public Node() // Default constructor
        {
            this.Name = null;
            this.Coordinate = null;
        }
        public Node(string name, Tuple<double, double> coordinate) // User-defined constructor
        {
            this.Name = name;
            this.Coordinate = coordinate;
        }
        public Node(string name, double latitude, double longitude)
        {
            this.Name = name;
            this.Coordinate = new Tuple<double, double>(latitude, longitude);
        }
        public string GetName()
        {
            return this.Name;
        }
        public double GetLatitude()
        {
            return this.Coordinate.Item1;
        }
        public double GetLongitude()
        {
            return this.Coordinate.Item2;
        }
        public double CalcPing(Node other)
        {
            // Referensi: https://moveable-type.co.uk/scripts/latlong.html
            double radius = 6371000;
            double radLat1 = (Math.PI / 180) * GetLatitude();
            double radLat2 = (Math.PI / 180) * other.GetLatitude();
            double dLat = (Math.PI / 180) * (other.GetLatitude() - GetLatitude());
            double dLong = (Math.PI / 180) * (other.GetLongitude() - GetLongitude());
            double a = Math.Pow(Math.Sin(dLat / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(dLong / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = radius * c;
            double calcPing = (distance / LIGHT) * 5 * 1000; // Ping in milliseconds
            return calcPing;
        }
        public void PrintInfo()
        {
            Console.WriteLine("Name\t: " + this.Name);
            Console.WriteLine("Coor\t: " + "(" + this.Coordinate.Item1 + ", " + this.Coordinate.Item2 + ")\n\n");
        }
        public void Print()
        {
            Console.WriteLine("Location: " + this.Name);
        }
    }
}
