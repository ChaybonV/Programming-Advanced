using System;

namespace Les_3
{
    public class DataStructures
    {

        public class Node
        {
            public string Data {  get; set; }
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

        //public class LinkedList
        //{
        //    //  opstart deze klasse + insert van een node
        //}

        public class LinkedList
        {
            private Node head { get; set; }

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

            public void Print()
            {
                Node current = head;
                while (current != null)
                {
                    Console.Write(current.ToString());
                    current = current.Next;
                }
                Console.WriteLine("null");
            }
        }




    }
}
