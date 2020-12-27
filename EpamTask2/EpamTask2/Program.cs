using EpamTask2.Parsers;
using EpamTask2.Services;
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
            IO inputOutput = new IO();
            //StreamReader sr = new StreamReader(textParser.filename);
            text = IO.Input(IO.InputFileName);
            Console.WriteLine("111"+text);
            Console.WriteLine("2222"+textParser.TextReparse(text.Sentences));
            foreach (Sentence sent in text.Sentences)
            {
                Console.WriteLine("1"+textParser.SentenceReparse(sent.Words));
            }
            Console.WriteLine("1 task "+text.PrintSortedText());
            Console.WriteLine("2 task " + text.FindWordsInSpecificSentences(SentenceType.Interrogative, 3));
            Console.WriteLine("3 task " + text.DeleteAllWordsStartingWithConsonant(4));
            foreach (Sentence sent in text.Sentences)
            {
                Console.WriteLine("4 task " + sent.ReplaceWordBySubstring(5,"epam"));
            }
            IO.Output(IO.OutputFileName, text);
        }
    }
}
