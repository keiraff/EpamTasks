using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Components
{
    public enum ChocolateType
    {
        unknown,
        milk,
        dark,
        white,
        mixed,
    }
    [Serializable]
    public class ChocolateBar:Candy
    {
        private ChocolateType chocolateType;
        public ChocolateType ChocolateType { get => chocolateType; set => chocolateType = value; }
        
        internal ChocolateBar(string name, double weight, double price, int calorie, int sugar, string manufacturer, FillingType candyFilling, ChocolateType type)
                    : base(name, weight, price, calorie, sugar, manufacturer,candyFilling)
        {
            ChocolateType = type;

        }
        public override string ToString()
        {
            return base.ToString()+ $" Type of chocolate: {ChocolateType}";
        }
        public ChocolateBar()
        {

        }
    }
}
