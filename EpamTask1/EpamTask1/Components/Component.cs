using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EpamTask1.Components

{
    [XmlInclude(typeof(ChocolateBar))]
    [XmlInclude(typeof(Waffle))]
    [XmlInclude(typeof(Bubblegum))]
    [XmlInclude(typeof(Lollipop))]
    [XmlInclude(typeof(Cookie))]
    [XmlInclude(typeof(Toy))]
    [XmlInclude(typeof(Fruit))]
    public abstract class Component
    {
        private double weight;
        public double Weight
        {
            get => weight;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Only positive number");
                }
                weight = value;
            }
        }
        private  string name;
        public string Name { get => name; set => name = value;   }
        private string manufacturer;
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        private double price;
        public double Price
        {
            get => price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Only positive number");
                }
                price = value;
            }
        }

        public Component()
        { }
        protected Component(string name, double weight,double price,string manufacturer)
        {
            Weight = weight;
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
        }

        public override string ToString()
        {
            return $"Name: {Name} Weight: {Weight} Price: {Price} Manufacturer: {Manufacturer}";
        }

    }
}
