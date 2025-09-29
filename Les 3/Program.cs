namespace Les_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataStructures.LinkedList list = new DataStructures.LinkedList();

            list.Insert("A");
            list.Insert("B");
            list.Insert("C");

            list.Print(); // Output: A --> B --> C --> null
        }
    }
}