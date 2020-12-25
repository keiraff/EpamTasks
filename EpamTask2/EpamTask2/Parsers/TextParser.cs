using EpamTask2.TextElements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EpamTask2.Parsers
{
    internal class TextParser
    {
        public string filename = "text.txt";
        private Separators separators;
        public Separators Separators { get => separators; set => separators = value; }
        public Text Parse(TextReader reader)
        {
            Separators = new Separators();
            int bufferlength = 10000;
            Text textResult = new Text();
            StringBuilder buffer = new StringBuilder(bufferlength);
            buffer.Clear();
            string currentString = reader.ReadLine();
            int currentLineNumber = 1;
            while (currentString != null)
            {
                currentString.Replace('\t', ' ');
                currentString = string.Join(" ", currentString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                string[] splitedSentences = Regex.Split(currentString, Separators.SentenceSeparatorsRegEx);
                for (int j = 0; j < splitedSentences.Length; j++)
                {
                    int line = currentLineNumber;
                    //foreach (char symbol in splitedSentences[j])
                    //{
                        //if (symbol == '\r')
                        //{
                            //currentLineNumber++;
                        //}
                    //}
                    if (splitedSentences[j] == splitedSentences[splitedSentences.Length - 1] && !String.IsNullOrEmpty(splitedSentences[j]))//if last sentence without punctuation mark in the end
                    {                                                                                             //and if only one sentence without punctuation mark in the end
                        //buffer.Append(" ");
                        buffer.Append(splitedSentences[j]);
                        //textResult.Sentences.Add(SentParse(sentences[sentences.Length - 1], line));
                    }
                    else if (splitedSentences[j] == splitedSentences[splitedSentences.Length - 1] && String.IsNullOrEmpty(splitedSentences[j])) continue;//if last sentence is empty or null
                    else
                    {
                        textResult.Sentences.Add(SentParse(buffer.Append(splitedSentences[j] + splitedSentences[j + 1]).ToString(), line));
                        buffer.Clear();
                        j++;
                    }
                }
                //text.lines = lineNumber;
                //text.pages = lineNumber / 25 + 1;
                currentString = reader.ReadLine();
            }
            return textResult;
        }
        public Sentence SentParse(string sentLine, int lineNumber)
        {
            Sentence sentence = new Sentence(sentLine);
            string[] words = sentLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool start = false;
            foreach (string item in words)
            {
                string word = "";
                string newLineTemp = "";
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] == '\r' && item[i + 1] == '\n')//if "/r/n" in the sentence
                    {
                        if (word != String.Empty)//if "/r/n" is after the word
                        {
                            sentence.Words.Add(WordParse(newLineTemp + word, lineNumber));
                            word = String.Empty;
                            newLineTemp = String.Empty;
                        }
                        lineNumber++;
                        i++;
                        newLineTemp += Environment.NewLine;
                    }
                    else if (start == false && item[i] != '\r' && item[i] != ' ')//if "/r/n" is first 2 chars of a sentence
                    {
                        start = true;
                        sentence.LineNumberOfSentence = lineNumber;
                        word += item[i];
                    }
                    else
                    {
                        word += item[i];
                    }
                }
                if (word != String.Empty)
                {
                    sentence.Words.Add(WordParse(newLineTemp + word, lineNumber));
                }
            }
            return sentence;
        }
        public Word WordParse(string wordLine, int lineNumber)
        {
            Separators = new Separators();
            char[] prepunctuationMarks =(char[])Separators.PrepunctuationMarks();
            char[] punctuationMarks = (char[])Separators.PunctuationMarks();
            Word word = new Word(lineNumber);
            foreach (char symbol in wordLine)
            {
                if ((word.Letters.Count == 0) && symbol == '\r')
                {
                    word.Prepunctuation.PunctuationMarks.Add(Environment.NewLine);
                }
                else if ((word.Letters.Count == 0) && symbol == '\n') continue;
                else if ((word.Letters.Count == 0) && (Array.Exists(prepunctuationMarks, element => element == symbol)))
                {
                    word.Prepunctuation.PunctuationMarks.Add(symbol.ToString());
                }
                else if ((word.Letters.Count != 0) &&  (Array.Exists(punctuationMarks, element => element == symbol)))
                        {
                    word.Punctuation.PunctuationMarks.Add(symbol.ToString());
                }
                else word.Letters.Add(symbol);
            }
            return word;
        }
        public Sentence SentenceReparse(ICollection<Word> collectionOfWords)
        {
            Sentence sentence = new Sentence(collectionOfWords);
            return SentParse(sentence.Value, sentence.LineNumberOfSentence);
        }

        public Text TextReparse(ICollection<Sentence> collectionOfSentences)
        {
            Text text = new Text(collectionOfSentences);
            return text;
        }
    }
}
