using System;

namespace Les_5
{
    public class Exercise
    {
        public int CountChar(string tekst, char character)
        {
            if (tekst.Length == 0)
            {
                return 0;
            }
            if (tekst[0] == character)
            {
                return 1 + CountChar(tekst.Substring(1), character);
            }
            else
            {
                return CountChar(tekst.Substring(1), character);
            }
        }
    }
}
