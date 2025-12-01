namespace Les_10
{
    public class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(4);
            tree.Add(2);
            tree.Add(8);
            tree.Add(6);

            Console.WriteLine("In-order traversal: ");
            tree.PrintInOrder(tree.Root);
            Console.WriteLine("\n");
            Console.WriteLine("Pre-order traversal: ");
            tree.PrintPreOrder(tree.Root);
            Console.WriteLine("\n");
            Console.WriteLine("Post-order traversal: ");
            tree.PrintPostOrder(tree.Root);
            Console.WriteLine("\n");


            Console.WriteLine("Min: " + tree.Min());
            Console.WriteLine("Max: " + tree.Max());

            Console.WriteLine("\nFound 4? " + tree.Search(4));
            Console.WriteLine("Found 10? " + tree.Search(10));

        }
    }
}
