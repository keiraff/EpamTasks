using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Components
{
    [Serializable]
    public class Fruit :Sweetness
    {
        private double vitaminC;
        public double VitaminC { get => vitaminC; set => vitaminC= value; }

        internal Fruit(string name, double weight, double price, int calorie, int sugar, double vitaminC)
            : base(name, weight, price,calorie,sugar)
        {
            if (vitaminC < 0&&vitaminC>100)
            {
                throw new ArgumentOutOfRangeException("Only positive number not greater than 100");
            }
            else VitaminC = vitaminC;
        }
        public Fruit()
        { }
        public override string ToString()
        {
            return $"Name: {Name} Weight: {Weight} Calorific Value: {Calorie} Price: {Price} Sugar Content: {Sugar} Amount of vitamin C:{VitaminC}";
        }
    }
}
