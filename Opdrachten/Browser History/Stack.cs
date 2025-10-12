using System;
using System.Collections.Generic;

namespace Browser_History
{
    public class Stack
    {
        private List<string> items;

        public Stack()
        {
            items = new List<string>();
        }

        public void Push(string data)
        {
            items.Add(data);
        }

        public string Pop()
        {
            if (items.Count == 0)
            {
                return null;
            }

            string value = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return value;
        }

        public bool IsEmpty()
        {
            return items.Count == 0;
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
