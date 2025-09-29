using System;

namespace Les_3
{
    public class LinkedListLes3
    {

        public class Node
        {
            public string Data { get; set; }
            public Node Next { get; set; }

            public Node(string data)
            {
                Data = data;
                Next = null;
            }

            public override string ToString()
            {
                return Data + " --> ";
            }
        }

        public class LinkedList
        {
            public Node head { get; set; }

            public LinkedList()
            {
                head = null;
            }

            public void Insert(string data)
            {
                Node newNode = new Node(data);

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    Node current = head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }
                    current.Next = newNode;
                }
            }

            public bool Delete(string data)
            {
                if (head == null)
                {
                    return false;
                }

                if (head.Data == data)
                {
                    head = head.Next;
                    return true;
                }

                Node current = head;
                while (current.Next != null && current.Next.Data != data)
                {
                    current = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool Search(string data)
            {
                Node current = head;
                while (current != null)
                {
                    if (current.Data == data)
                    {
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }

            public override string ToString()
            {
                string print = "";
                Node current = head;
                while (current != null)
                {
                    print += current;
                    current = current.Next;
                }
                return print;
            }
        }

    }
}
