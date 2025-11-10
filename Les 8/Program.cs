namespace Les_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze(25);

            maze.addEdge(0, 1);
            maze.addEdge(1, 2);
            maze.addEdge(2, 3);
            maze.addEdge(3, 4);
            maze.addEdge(4, 9);
            maze.addEdge(9, 14);
            maze.addEdge(18, 17);
            maze.addEdge(18, 19);
            maze.addEdge(19, 14);
            maze.addEdge(19, 24);
            maze.addEdge(24, 23);
            maze.addEdge(18, 23);
            maze.addEdge(22, 23);
            maze.addEdge(17, 12);
            maze.addEdge(21, 22);
            maze.addEdge(21, 20);
            maze.addEdge(20, 15);
            maze.addEdge(15, 10);
            maze.addEdge(10, 5);
            maze.addEdge(5, 0);
            Console.WriteLine(maze.ToString());


            Console.WriteLine("path DFS Recursion: "+maze.DFS_Rec(12));
            Console.WriteLine(maze.DFS(12));

            Console.WriteLine(maze.BFS(12));
        }
    }
}
