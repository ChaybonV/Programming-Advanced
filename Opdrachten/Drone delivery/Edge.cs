using System;

namespace Drone_delivery
{
    public class Edge
    {
        public string To;
        public int Cost;

        public Edge(string to, int cost)
        {
            To = to;
            Cost = cost;
        }
    }
}
