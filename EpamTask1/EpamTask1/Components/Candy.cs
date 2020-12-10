using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Components
{
    public enum FillingType
    {
        noFilling,
        chocolate,
        jelly,
        caramel,
        nougat,
        nuts,
        bubblegum
    }
    public abstract class Candy : Sweetness
    {
        private FillingType candyFilling;
        public FillingType Filling { get=>candyFilling; set=>candyFilling=value; }
        protected Candy(string name, double weight, double price, int calorie, int sugar, string manufacturer, FillingType candyFilling)
            : base(name, weight, price, calorie, sugar,manufacturer)
        {
            Filling = candyFilling;
        }
        public override string ToString()
        {
            return base.ToString()+ $" Filling: {Filling}";
        }
        public Candy()
        {

        }
    }
}
