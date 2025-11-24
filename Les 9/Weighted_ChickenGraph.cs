using System;
using System.Collections.Generic;

namespace Les_9
{
    class Weighted_ChickenGraph
    {
        public class Edge
        {
            public int To { get; set; }
            public int Weight { get; set; }

            public Edge(int to, int weight)
            {
                To = to;
                Weight = weight;
            }
        }

        List<Edge>[] adj_list;

        public Weighted_ChickenGraph(int nodes)
        {
            adj_list = new List<Edge>[nodes];
            for (int i = 0; i < nodes; i++)
            {
                adj_list[i] = new List<Edge>();
            }
        }

        public void AddEdge(int start, int end, int weight)
        {
            adj_list[start].Add(new Edge(end, weight));
            adj_list[end].Add(new Edge(start, weight));
        }

        private int NextNode(int[] distances, bool[] visited)
        {
            int node = -1;
            int min_distance = Int32.MaxValue;

            for (int i = 0; i < distances.Length; i++)
            {
                if (!visited[i] && distances[i] < min_distance)
                {
                    min_distance = distances[i];
                    node = i;
                }
            }

            return node;
        }

        public string Dijkstra(int start, int end)
        {
            int[] distances = new int[adj_list.Length];
            bool[] visited = new bool[adj_list.Length];
            int[] path = new int[adj_list.Length];

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = Int32.MaxValue;
                path[i] = -1;
            }

            distances[start] = 0;

            while (true)
            {
                int node = NextNode(distances, visited);
                if (node == -1)
                {
                    break;
                }
                if (node == end)
                {
                    break;
                }

                visited[node] = true;

                foreach (Edge edge in adj_list[node])
                {
                    int neighbor = edge.To;
                    int cost = distances[node] + edge.Weight;

                    if (cost < distances[neighbor])
                    {
                        distances[neighbor] = cost;
                        path[neighbor] = node;
                    }
                }
            }

            if (distances[end] == Int32.MaxValue)
            {
                return $"Er bestaat geen pad tussen {start} en {end}";
            }

            string result = "";
            result += "Kortste pad kost " + distances[end] + "\n";

            int n = end;
            while (n != start)
            {
                result += n + " ";
                n = path[n];
            }

            result += start;
            return result;
        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < adj_list.Length; i++)
            {
                result += i + " --> ";
                foreach (Edge edge in adj_list[i])
                {
                    result += edge.To + " " + edge.Weight + " ";
                }
                result += "\n";
            }

            return result;
        }
    }
}
