using System;

namespace Les_3
{
    public class StackLes3
    {

        public class Stack
        {
            public int maxSize {  get; private set; }
            string[] array;
            int index;

            public Stack(int size)
            {
                array = new string[size];
                index = 0;
            }

            public void Push(string data)
            {
                if(index < array.Length)
                {
                    array[index] = data;
                    index++;
                }
                else
                {
                    //throw new OverflowException();
                    index = array.Length - 1;
                    throw new Exception("Overflow!");
                }
            }

            public void Pop()
            {
                if (index == 0)
                {
                    throw new Exception("Underflow!");
                }
                index--;
                array[index] = null;
            }

            public override string ToString()
            {
                string print = "";
                foreach(string element in array)
                {
                    print+= element+" | ";
                }
                return print;
            }


        }
    }
}
