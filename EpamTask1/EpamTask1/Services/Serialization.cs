using EpamTask1.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EpamTask1.Services
{
    public class Serialization
    {
        //XmlSerializer serializer = new XmlSerializer(typeof(Gift));
        public static Gift SerializationOfGift(Gift gift)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Gift));
            using (FileStream fs = new FileStream("gift.xml", FileMode.Create))
            {
                serializer.Serialize(fs, gift);
                Console.WriteLine("Serialization is done.");
            }
            return gift;
        }
        public static List<Component> DeserializationOfGift(string fileName)
        {
            //Type[] types =
            //{
            //typeof(Candy),
            //typeof(Toy),
            //typeof(Fruit),
            //typeof(Cookie)
            //};
            XmlSerializer formatter = new XmlSerializer(typeof(List<Component>));
            //Gift gift;
            List<Component> allPossibleComponents = new List<Component>();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                allPossibleComponents = (List<Component>)formatter.Deserialize(fs);
            }
            return allPossibleComponents;
        }
    }
}
