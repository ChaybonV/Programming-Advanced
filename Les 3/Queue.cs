using System;

namespace Les_3
{
    public class Queue
    {

        LinkedListLes3.LinkedList list = new LinkedListLes3.LinkedList();

        public Queue()
        {
            list = new LinkedListLes3.LinkedList();
        }

        public void Enqueue(string data)
        {
            list.Insert(data);
        }

        public void Dequeue()
        {
            list.Delete(list.head.Data);
        }

        public override string ToString()
        {
            return list.ToString();
        }
    }
}
