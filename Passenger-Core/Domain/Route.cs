using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
    public class Route
    {
        public string Name { get; protected set; }
        public Node StartNode { get; protected set; }
        public Node EndNode { get; protected set; }
        public double Distance { get; protected set; }

        private Route() { }
        public Route(string name, Node start, Node end, double distance)
        {
            SetEndNode(end);
            SetStartNode(start);
            SetName(name);
            //distance = odległosc miedzy end and start;
        }
       
        public static Route CreateRoute(string name, Node start, Node end, double distance)
        => new Route(name, start, end, distance);
        private void SetName(string name)
        {

            Name = name;
        }
        private void SetStartNode(Node startNode)
        {
            StartNode = startNode;
        }
        private void SetEndNode(Node endNode)
        {
            EndNode = endNode;
        }
    }
}
