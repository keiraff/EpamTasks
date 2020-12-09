using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Components
{

    public enum FlavorType
    {
        unknown,
        chocolate,
        caramel,
        jelly,
        bubblegum,
    }
    [Serializable]
    public class Candy : Sweetness
    {
        private FlavorType candyFlavor;
        public FlavorType CandyFlavor { get=>candyFlavor;  set=>candyFlavor = value;  }
        internal Candy(string name, double weight, double price, int calorie, FlavorType flavor, int sugar)
            : base(name, weight, price, calorie, sugar)
        {
            CandyFlavor = flavor;
        }
        public override string ToString()
        {
            return $"Name: {Name} Weight: {Weight} Calorific Value: {CalorificValue} Price: {Price} Sugar Content: {SugarContent} Candy Flavor:{CandyFlavor}";
        }
        public Candy()
        {

        }
    }
}
