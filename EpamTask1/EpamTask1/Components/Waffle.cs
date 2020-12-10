using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Components
{
    public enum WaffleTaste
    { 
    chocolate,
    vanilla,
    cocoa,
    }
    [Serializable]
    public class Waffle : Sweetness
    {
        private WaffleTaste taste;
        public WaffleTaste WaffleTaste { get => taste; set => taste = value; }
        internal Waffle(string name, double weight, double price, int calorie, WaffleTaste taste, int sugar, string manufacturer)
            : base(name, weight, price, calorie, sugar, manufacturer)
        {
            WaffleTaste = taste;
        }
        public override string ToString()
        {
            return base.ToString()+ $" Waffle Taste:{WaffleTaste}";
        }
        public Waffle()
        {

        }

    }
   
}
