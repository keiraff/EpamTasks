using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Components
{
    public enum BubblegumTaste
    { 
    apple,
    watermelon,
    mint,
    strawberry,
    coke,
    cherry,
    }
    [Serializable]
    public class Bubblegum: Candy
    {
        private BubblegumTaste taste;
        public BubblegumTaste BubblegumTaste { get => taste;  set => taste = value; }
        private int amount;
        public int AmountInPack
        {
            get => amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Only positive number");
                }
                amount = value;
            }
        }
        internal Bubblegum(string name, double weight, double price, int calorie, int sugar, string manufacturer, FillingType candyFilling, BubblegumTaste taste, int amount)
                    : base(name, weight, price, calorie, sugar, manufacturer,candyFilling)
        {
            BubblegumTaste = taste;
            AmountInPack = amount;
           
        }
        public override string ToString()
        {
            return base.ToString()+ $" Taste: {BubblegumTaste} Amount in pack: {AmountInPack}";
        }
        public Bubblegum()
        { 
        
        }
    }
}
