using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Klark_Right.Models
{
    public class Point
    {
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Demand Demand { get; set; }

        public Point(int id, int x, int y)
            => (Id, X, Y) = (id, x, y);

        public Point(int id, int x, int y, Demand demand)
            => (Id, X, Y, this.Demand) = (id, x, y, demand);

        public bool HasBeenVisited { get; set; }

        public double DistanceToPoint(Point otherPoint)
        {
            double x = X - otherPoint.X;
            double y = Y - otherPoint.Y;
            return Math.Sqrt(x * x + y * y);
        }

        public override string ToString()       //every point of every algorithm would be written in a formatted way
            => $"Point {Id}: {X} {Y}";
    }
}
