using EpamTask1.Components;
using EpamTask1.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EpamTask1
{
    [Serializable]
    [XmlInclude(typeof(Candy))]
    [XmlInclude(typeof(Cookie))]
    [XmlInclude(typeof(Toy))]
    [XmlInclude(typeof(Fruit))]

    public class Gift
    {
        [XmlArrayItem(Type = typeof(Candy))]
        [XmlArrayItem(Type = typeof(Cookie))]
        [XmlArrayItem(Type = typeof(Toy))]
        [XmlArrayItem(Type = typeof(Fruit))]
        public List<Component> giftComponents = new List<Component>();
        public double GiftWeight
        {
            get 
            {
                double totalWeight=0;
                foreach (Component item in giftComponents)
                { 
                    totalWeight += item.Weight;
                }
                return totalWeight;
            }
        }
        public double GiftPrice
        {
            get
            {
                double totalPrice = 0;
                foreach (Component item in giftComponents)
                {
                    totalPrice += item.Price;
                }
                return totalPrice;
            }
        }
        public void SortByPrice()
        {
            giftComponents.Sort(new ComparerByPrice());
            
        }
        public void SortByWeight()
        {
            giftComponents.Sort(new ComparerByWeight());

        }
        public List<Component> SugarContentRange(int firstLimit, int secondLimit)
        {
            List<Component> list = new List<Component>();
            foreach (Component item in giftComponents)
            {
                if (item is Sweetness)
                {
                    if ((item as Sweetness).Sugar > firstLimit && (item as Sweetness).Sugar < secondLimit)
                    {
                        list.Add(item);
                    }
                }
            }
            if (list.Count == 0) return null;
            return list;
        }
        public override string ToString()
        {
            StringBuilder line = new StringBuilder();
            foreach (var item in giftComponents)
            {
                line.Append(item.ToString() + "\n");
            }
            line.Append("Total Weight: " + this.GiftWeight + "\n");
            line.Append("Total Price: " + this.GiftPrice + "\n");
            return line.ToString();
        }

    }
}
