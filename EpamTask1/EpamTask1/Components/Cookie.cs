using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Components
{
    public enum CookieType
    {
        unknown,
        oat,
        cracker,
        ginger,
        chocolate,
    }
    [Serializable]
    public class Cookie:Sweetness
    {
        private CookieType taste;
        public CookieType CookieTaste { get => taste; set => taste = value; }
        internal Cookie(string name, double weight, double price, int calorie, CookieType taste, int sugar)
            : base(name, weight, price, calorie, sugar)
        {
            CookieTaste = taste;
        }
        public override string ToString()
        {
            return $"Name: {Name} Weight: {Weight} Calorific Value: {Calorie} Price: {Price} Sugar Content: {Sugar} Cookie Taste:{CookieTaste}";
        }
        public Cookie()
        { }
    }
}
