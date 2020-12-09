using EpamTask1.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EpamTask1
{
    class GiftBuilder
    {
        List<Component> allComponents = Services.Serialization.DeserializationOfGift("database.xml");//ReadFromXMLfile("database.xml");

        //public void Output()
        //{
        //    if (allComponents.Count > 0)
        //    {
        //        foreach (var item in allComponents)
        //        {
        //            Console.WriteLine(item.Name);
        //        }
        //    }
        //    else Console.WriteLine("!!!!");
        //}
        public Gift CreateRandomGift(int amount)
        {
            Gift gift = new Gift();
            if (amount > 0)
            {
                while (amount != 0)
                {
                    gift.giftComponents.Add(allComponents[new Random().Next(0, allComponents.Count)]);
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
                    gift.giftComponents.Add(item);
                }
            }
            return gift;
        }
        //public static List<Component> ReadFromXMLfile(string XMLfileName)
        //{
        //    List<Component> components = new List<Component>();
        //    XmlDocument xmlDocument = new XmlDocument();
        //    xmlDocument.Load(XMLfileName);
        //    XmlElement xmlElement = xmlDocument.DocumentElement;
        //    foreach (XmlNode node in xmlElement)
        //    {
        //        string type = "";
        //        string name = "";
        //        double weight = 0;
        //        int calorie = 0;
        //        FlavorType flavor=FlavorType.unknown;
        //        CookieType taste = CookieType.unknown;
        //        double price = 0;
        //        int sugar = 0;
        //        foreach (XmlNode childnode in node.ChildNodes)
        //        {

        //            if (childnode.Name == "Name")
        //            {
        //                name = childnode.InnerText;
        //            }
        //            if (childnode.Name == "Weight")
        //            {
        //                weight = Convert.ToDouble(childnode.InnerText);
        //            }
        //            if (childnode.Name == "Calorie")
        //            {
        //                calorie = Convert.ToInt32(childnode.InnerText);
        //            }
        //            if (childnode.Name == "Sugar")
        //            {
        //                sugar = Convert.ToInt32(childnode.InnerText);
        //            }
        //            if (childnode.Name == "CandyFlavor")
        //            {
        //                FlavorType.TryParse(childnode.InnerText, out flavor);
        //            }
        //            if (childnode.Name == "CookieTaste")
        //            {
        //                CookieType.TryParse(childnode.InnerText, out taste);
        //            }
        //            if (childnode.Name == "Price")
        //            {
        //                price = Convert.ToDouble(childnode.InnerText);
        //            }
        //            if (childnode.Name == "Type")
        //            {
        //                type = childnode.InnerText;
        //            }
        //        }
        //        switch (type)
        //        {
        //            case "Toy":
        //                components.Add(new Toy(name, weight, price));
        //                break;
        //            case "Cookie":
        //                components.Add(new Cookie(name, weight, price, calorie,taste,sugar));
        //                break;
        //            case "Candy":
        //                components.Add(new Candy(name, weight, price, calorie,flavor,sugar));
        //                break;
        //            case "Fruit":
        //                components.Add(new Fruit(name, weight, price, calorie,sugar));
        //                break;
        //        }
        //    }
        //    return components;
        //}

    }
}
