using EpamTask2.Parsers;
using EpamTask2.TextElements;
using System;
using System.Collections.Generic;
using System.IO;

namespace EpamTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Text text = new Text();
            TextParser textParser = new TextParser();
            StreamReader sr = new StreamReader(textParser.filename);
            text = textParser.Parse(sr);
            Console.WriteLine("111"+text);
            Console.WriteLine("2222"+textParser.TextReparse(text.Sentences));
            foreach (Sentence sent in text.Sentences)
            {
                Console.WriteLine("1"+textParser.SentenceReparse(sent.Words));
            }
            Console.WriteLine("1 task "+text.PrintSortedText());
            
        }
    }
}
