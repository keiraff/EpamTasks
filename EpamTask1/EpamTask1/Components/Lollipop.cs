using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Components
{
    public enum LollipopTaste
    { 
        unknown,
        berries,
        fruitMix,
        orange,
        coke,
        apple,
        pear,
    }
    [Serializable]
    public class Lollipop : Candy
    {
        private LollipopTaste taste;
        public LollipopTaste LollipopTaste { get => taste; set => taste = value; }
        private bool isContainBubbleGum;
        public bool IsContainBubbleGum { get => isContainBubbleGum; set => isContainBubbleGum = value; }
        internal Lollipop(string name, double weight, double price, int calorie, int sugar, string manufacturer, FillingType candyFilling, LollipopTaste taste, bool isContainBubbleGum)
                    : base(name, weight, price, calorie, sugar, manufacturer, candyFilling)
        {
            LollipopTaste = taste;
            IsContainBubbleGum = isContainBubbleGum;

        }

        public override string ToString()
        {
            return $"Name: {Name} Weight: {Weight} Calorific Value: {CalorificValue} Price: {Price} Manufacturer:{Manufacturer} Sugar Content: {SugarContent}" +
                $" Filling: {Filling} Taste: {LollipopTaste} With bubblegum: {IsContainBubbleGum}";
        }
        public Lollipop()
        {

        }
    }
}
