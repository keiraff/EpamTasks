using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Components
{
    [Serializable]
    public class Fruit :Sweetness
    {
        private double contentOfVitaminC;
        public double ContentOfVitaminC
        {
            get => contentOfVitaminC;
            set
            {
                if (value < 0 && value > 100)
                {
                    throw new ArgumentOutOfRangeException("Only positive number not greater than 100");
                }
                contentOfVitaminC = value;
            }
        }
        internal Fruit(string name, double weight, double price, int calorie, int sugar, double vitaminC, string manufacturer)
            : base(name, weight, price, calorie, sugar,manufacturer)
        {
            ContentOfVitaminC = vitaminC;
        }
        public Fruit()
        { 
        
        }
        public override string ToString()
        {
            return  base.ToString()+ $" Amount of vitamin C:{ContentOfVitaminC}";
        }
    }
}
