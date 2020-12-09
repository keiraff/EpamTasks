using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Components
{
    [Serializable]
    public class Fruit :Sweetness
    {
        private double contentOfVitaminC;
        public double ContentOfVitaminC { get => contentOfVitaminC; set => contentOfVitaminC= value; }

        internal Fruit(string name, double weight, double price, int calorie, int sugar, double vitaminC)
            : base(name, weight, price, calorie, sugar)
        {
            if (vitaminC < 0 && vitaminC > 100)
            {
                throw new ArgumentOutOfRangeException("Only positive number not greater than 100");
            }
            ContentOfVitaminC = vitaminC;
        }
        public Fruit()
        { }
        public override string ToString()
        {
            return $"Name: {Name} Weight: {Weight} Calorific Value: {CalorificValue} Price: {Price} Sugar Content: {SugarContent} Amount of vitamin C:{ContentOfVitaminC}";
        }
    }
}
