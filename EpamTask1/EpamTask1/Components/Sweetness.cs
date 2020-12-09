using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EpamTask1.Components
{
    [XmlInclude(typeof(Candy))]
    [XmlInclude(typeof(Cookie))]
    [XmlInclude(typeof(Fruit))]
    public abstract class Sweetness : Component
    {
        private int calorificValue;
        public int CalorificValue
        {
            get => calorificValue;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Only positive number");
                }
                calorificValue = value;
            }
        }

        private int sugarContent;
        public int SugarContent
        {
            get => sugarContent;
            set
            {
                if (value < 0 && value > 100)
                {
                    throw new ArgumentOutOfRangeException("Only positive number not greater than 100");
                }
                sugarContent = value;
            }
        }
        protected Sweetness(string name, double weight, double price, int calorie, int sugar, string manufacturer)
            : base(name, weight, price, manufacturer)
        {
            SugarContent = sugar;
            CalorificValue = calorie;
        }
        public Sweetness()
        { }
        public override string ToString()
        {
            return $"Name: {Name} Weight: {Weight} Calorific Value: {CalorificValue} Price: {Price} Manufacturer:{Manufacturer} Sugar Content: {SugarContent}";
        }
    }
}
