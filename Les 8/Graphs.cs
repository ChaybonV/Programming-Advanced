using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Les_8
{
    public class Maze
    {
        int[,] matrix;
        public Maze(int nodes)
        {
            matrix = new int[nodes, nodes];
        }

        public void addEdge(int x, int y)
        {
            matrix[x, y] = 1;
            matrix[y, x] = 1;
        }

        public string DFS(int startnode)
        {
            string path = "path DFS: ";
            bool[] visited = new bool[matrix.GetLength(0)];
            Stack<int> stack = new Stack<int>();

            // We zetten startnode op de stack
            stack.Push(startnode);

            // Bezocht markeren
            visited[startnode] = true;

            // Zolang er nodes op de stack staan gaan we verder
            while (stack.Count != 0)
            {
                int node = stack.Pop();
                path += node + " ";

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[node, i] != 0 && !visited[i])
                    {
                        stack.Push(i);
                        visited[i] = true;
                    }
                }
            }

            return path;
        }

        public string DFS_Rec(int startnode, bool[] visited = null)
        {
            if (visited == null)
            {
                visited = new bool[matrix.GetLength(0)];
            }

            visited[startnode] = true;
            string path = startnode + " ";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[startnode, i] != 0 && !visited[i])
                {
                    path += DFS_Rec(i, visited);
                }
            }

            return path;
        }

        public string BFS(int startnode)
        {
            string path = "path BFS: ";
            bool[] visited = new bool[matrix.GetLength(0)];
            Queue<int> queue = new Queue<int>();

            // Startnode op de queue zetten en markeren als bezocht
            queue.Enqueue(startnode);
            visited[startnode] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                path += node + " ";

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[node, i] != 0 && !visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }

            return path;
        }

        public override string ToString()
        {
            string result = "***MATRIX OUTPUT\n\t";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result += i + "\t";
            }
            result += "\n";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result += i + "\t";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        result += matrix[i, j] + "\t";
                    }
                    else
                    {
                        result += "\t";
                    }
                }
                result += "\n";
            }

            result += "\n***LIST OUTPUT\n";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result += i + " --> ";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        result += j + " ";
                    }
                }
                result += "\n";
            }
            return result;
        }

    }
}
