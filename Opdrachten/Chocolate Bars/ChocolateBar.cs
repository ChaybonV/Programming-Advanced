using System;

namespace Chocolate_Bars
{
    public class ChocolateBar
    {
        public string Name { get; set; }
        public int Sweetness { get; set; }
        public int OriginalOrder { get; set; }

        public ChocolateBar(string name, int sweetness, int originalOrder)
        {
            Name = name;
            Sweetness = sweetness;
            OriginalOrder = originalOrder;
        }

        public override string ToString()
        {
            return $"{Name}:{Sweetness}";
        }
    }
}
