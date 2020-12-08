using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EpamTask1.Components
{
    //[Serializable]
    [XmlInclude(typeof(Candy))]
    [XmlInclude(typeof(Cookie))]
    [XmlInclude(typeof(Fruit))]
    public abstract class Sweetness : Component
    {
        private int calorificValue;
        public int Calorie { get => calorificValue; set => calorificValue = value; }

        private int sugarContent;
        public int Sugar { get { return sugarContent; } set { sugarContent = value; } }
        protected Sweetness(string name, double weight, double price,int calorie,int sugar)
            : base(name, weight, price)
        {
            if (sugar < 0&&sugar>100)
            {
                throw new ArgumentOutOfRangeException("Only positive number not greater than 100");
            }
            else Sugar = sugar;
            if (calorie <= 0)
            {
                throw new ArgumentOutOfRangeException("Only positive number");
            }
            else Calorie = calorie;
        }
        public Sweetness()
        { }
        public override string ToString()
        {
            return $"Name: {Name} Weight: {Weight} Calorific Value: {Calorie} Price: {Price} Sugar Content: {Sugar}";
        }
    }
}
