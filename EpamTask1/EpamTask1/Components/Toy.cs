using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Components
{
    public enum ToyType
    { 
    unisex,
    forGirl,
    forBoy,
    }
   [Serializable]
     public class Toy : Component
    {
        private ToyType typeOfToy;
        public ToyType TypeOfToy { get => typeOfToy; set => typeOfToy = value; }
        internal Toy(string name, double weight, double price, ToyType type)
            :base(name,weight,price)
        {
            TypeOfToy = type;
        }
        public Toy()
        { }
        public override string ToString()
        {
            return $"Name: {Name} Weight: {Weight} Price: {Price} Type of toy:{TypeOfToy}";
        }
    }
}
