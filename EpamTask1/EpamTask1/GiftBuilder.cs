using EpamTask1.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EpamTask1
{
    public class GiftBuilder
    {
        IList<Component> allComponents = Services.Serialization.DeserializationOfGift("database.xml");
        public Gift CreateRandomGift(int amount)
        {
            Gift gift = new Gift();
            if (amount > 0)
            {
                while (amount != 0)
                {
                    gift.GiftComponents.Add(allComponents[new Random().Next(0, allComponents.Count)]);
                    amount--;
                }
            }
            return gift;
        }

        public Component GetRandomComponent()
        {
            return allComponents[new Random().Next(0, allComponents.Count)];
        }
        public Component GetComponentByName(string name)
        {
            foreach (var item in allComponents)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
        public Gift CreateGiftOfToys()
        {
            Gift gift = new Gift();
            foreach (var item in allComponents)
            {
                if (item is Toy)
                {
                    gift.GiftComponents.Add(item);
                }
            }
            return gift;
        }

    }
}
