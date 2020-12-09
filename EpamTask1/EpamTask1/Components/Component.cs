using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EpamTask1.Components

{
    [XmlInclude(typeof(Candy))]
    [XmlInclude(typeof(Cookie))]
    [XmlInclude(typeof(Toy))]
    [XmlInclude(typeof(Fruit))]
    public abstract class Component
    {
        private double weight;
        public double Weight { get=> weight;  set =>weight = value;  }
        private  string name;
        public string Name { get => name;  set => name = value;   }
        private double price;
        public double Price { get => price; set => price = value;  }

        public Component()
        { }
        protected Component(string name, double weight,double price)
        {
            if (weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Only positive number");
            }
            Weight = weight;
            Name = name;
            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException("Only positive number");
            }
            Price = price;

        }
        

    }
}
