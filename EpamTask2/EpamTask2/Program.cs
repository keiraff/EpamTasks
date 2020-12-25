using EpamTask2.Parsers;
using EpamTask2.TextElements;
using System;
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
            Console.WriteLine(text);
        }
    }
}
