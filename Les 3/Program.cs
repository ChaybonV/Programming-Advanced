using System;

namespace Les_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedListLes3.LinkedList list = new LinkedListLes3.LinkedList();
            list.Insert("A");
            list.Insert("B");
            list.Insert("C");

            Console.WriteLine(list.ToString()); // Output: A --> B --> C -->

            Console.WriteLine("Verwijder B: "+list.Delete("B")); // True -> B is in list so it is possible to delete
            Console.WriteLine(list.ToString()); // Output: A --> C -->

            Console.WriteLine(list.Search("A")); // True -> A is founded in list
            Console.WriteLine(list.Search("Z")); // False -> Z is not founded in list


            Console.WriteLine("\n----------------------------\n----------------------------\n");


            StackLes3.Stack list2 = new StackLes3.Stack(5);
            list2.Push("Appel"); Console.WriteLine(list2.ToString());
            list2.Push("Appel"); Console.WriteLine(list2.ToString());
            list2.Push("Appel"); Console.WriteLine(list2.ToString());
            list2.Push("Appel"); Console.WriteLine(list2.ToString());
            list2.Push("Appel"); Console.WriteLine(list2.ToString());
            //list2.Push("Appel"); Console.WriteLine(list2.ToString());

            list2.Pop(); Console.WriteLine(list2.ToString());
            list2.Pop(); Console.WriteLine(list2.ToString());
            list2.Pop(); Console.WriteLine(list2.ToString());
            list2.Pop(); Console.WriteLine(list2.ToString());
            list2.Pop(); Console.WriteLine(list2.ToString());
            //list2.Pop(); Console.WriteLine(list2.ToString());


            Console.WriteLine("\n----------------------------\n----------------------------\n");


            Queue queue = new Queue();
            queue.Enqueue("Appel"); Console.WriteLine(queue.ToString());
            queue.Enqueue("Appel"); Console.WriteLine(queue.ToString());
            queue.Enqueue("Appel"); Console.WriteLine(queue.ToString());
            queue.Enqueue("Appel"); Console.WriteLine(queue.ToString());
            queue.Enqueue("Appel"); Console.WriteLine(queue.ToString());

            queue.Dequeue(); Console.WriteLine(queue.ToString());
            queue.Dequeue(); Console.WriteLine(queue.ToString());
            queue.Dequeue(); Console.WriteLine(queue.ToString());
            queue.Dequeue(); Console.WriteLine(queue.ToString());
            queue.Dequeue(); Console.WriteLine(queue.ToString());
        }
    }
}
