using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using EpamTask1.Components;

namespace EpamTask1
{
    class Program
    {
        static void Main(string[] args) 
        {
            GiftBuilder giftBuilder = new GiftBuilder();
            Gift gift = new Gift();
            int command = Menu();
            do
            {
                switch (command)
                {
                    case 1:
                        {
                            Console.WriteLine("Input the number of components in our gift:");
                            int number;
                            while (!Int32.TryParse(Console.ReadLine(), out number))
                            {
                                Console.WriteLine("Error! Input a number:");
                            }
                            gift = giftBuilder.CreateRandomGift(number);
                            Console.WriteLine(gift);
                            command = Menu();
                            break;
                        }
                    case 2:
                        {
                            gift = giftBuilder.CreateGiftOfToys();
                            Console.WriteLine(gift);
                            command = Menu();
                            break;
                        }
                    case 3:
                        {
                            gift.SortByPrice();
                            Console.WriteLine(gift);
                            command = Menu();
                            break;
                        }
                    case 4:
                        {
                            gift.SortByWeight();
                            Console.WriteLine(gift);
                            command = Menu();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Input space-separated first and second limit:");
                            string input = Console.ReadLine();
                            string[] temp = input.Split(new Char[] { ' ' });
                            int firstLimit, secondLimit;
                            while (!Int32.TryParse(temp[0], out firstLimit) || !Int32.TryParse(temp[1], out secondLimit))
                            {
                                Console.WriteLine("Error! Only integer numbers. Repeat the input:");
                                input = Console.ReadLine();
                                temp = input.Split(new Char[] { ' ' });
                            }
                            List<Component> list = gift.FindSweetnessesFromSugarContentRange(firstLimit,secondLimit);
                            foreach (var item in list)
                            {
                                Console.WriteLine(item);
                            }
                            command = Menu();
                            break;
                        }
                    case 6:
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Gift));
                            Services.Serialization.SerializationOfGift(gift, gift.fileName);
                            command = Menu();
                            break;
                        }
                    case 7:
                        {
                            gift.AddComponentToGift(giftBuilder.GetRandomComponent());
                            Console.WriteLine(gift);
                            command = Menu();
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Input name of component:");
                            string input = Console.ReadLine();
                            gift.AddComponentToGift(giftBuilder.GetComponentByName(input));
                            Console.WriteLine(gift);
                            command = Menu();
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("Input name of component:");
                            string input = Console.ReadLine();
                            gift.RemoveComponentFromGiftByName(input);
                            Console.WriteLine(gift);
                            command = Menu();
                            break;
                        }
                    case 0: break;
                    default:
                        {
                            command = Output();
                            break;
                        }
                }
            } while (command != 0);

        }
        public static int Menu()
        {
            Console.WriteLine("1->Create a random gift.\n" +
                "2->Create gift of toys.\n" +
                "3->Sort gift by price.\n" +
                "4->Sort gift by weight.\n" +
                "5->Find sweetness from sugar content range.\n" +
                "6->Input gift information to xml file.\n" +
                "7->Add random component to the gift.\n"+
                "8->Add component to the gift by name.\n"+
                "9->Remove all components by name.\n"+
                "0->exit.\n");
            return Output();
        }
        public static int Output()
        {
            int command;
            Console.WriteLine("Input command:");
            while (!Int32.TryParse(Console.ReadLine(), out command))
            {
                Console.WriteLine("Error! Input a number:");
            }
            return command;
        }
    }
}
