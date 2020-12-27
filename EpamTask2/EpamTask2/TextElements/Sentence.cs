using EpamTask2.Parsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask2.TextElements
{
    public enum SentenceType
    {
        Invalid,
        Declarative,
        Exclamatory,
        Interrogative,
        NotEnded,
    }
    internal class Sentence:IEditable<Word>
    {
        private ICollection<Word> words;
        private SentenceType typeOfSentence;
        private int lineNumberOfSentence;
        //private string sentenceValue;
        public int LineNumberOfSentence { get => lineNumberOfSentence; set => lineNumberOfSentence = value; }
        public ICollection<Word> Words { get => words; private set => words = value; }
        public SentenceType TypeOfSentence { get => typeOfSentence; private set => typeOfSentence=value; }
        public int Length { get; set; }
        
        public string Value
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var word in this.Words)
                {
                    if ((Words as List<Word>).IndexOf(word) == Words.Count - 1)
                    {
                        sb.Append(word.SentenceElementValue);
                    }
                    else sb.Append(word.SentenceElementValue + " ");
                }
                return sb.ToString();
            }
        }
        public Sentence()
        {
            Words = new List<Word>();
        }
        public Sentence(string value)
        {
            Words = new List<Word>();
            TypeOfSentence = GetTypeOfSentence(value);
            Length = value.Length;
            //Value = value;
        }
        public Sentence(ICollection<Word> collectionOfWords)
        {
            Words = collectionOfWords;
            LineNumberOfSentence = (collectionOfWords as List<Word>)[0].LineNumberOfWord;
            //TypeOfSentence = GetTypeOfSentence(value);
            //Length = value.Length;
            //Value = value;
        }
        public Sentence ReplaceWordBySubstring(int wordLength, string substring)
        {
            TextParser parser = new TextParser();
            string value = "";
            foreach (var word in this.Words)
            {
                if (word.Value.Length == wordLength)
                {
                    value += word.Prepunctuation.Value + substring + word.Punctuation.Value + " ";
                }
                else value += word.Prepunctuation.Value + word.Value + word.Punctuation.Value + " ";
            }
            return parser.SentParse(value, this.LineNumberOfSentence);
        }
        public int GetAmountOfWords
        {
            get => Words.Count;
        }
        public SentenceType GetTypeOfSentence(string sent)
        {
            if (sent.EndsWith("!"))
            {
                return SentenceType.Exclamatory;
            }
            else if (sent.EndsWith("."))
            {
                return SentenceType.Declarative;
            }
            else if (sent.EndsWith("?"))
            {
                return SentenceType.Interrogative;
            }
            else if (sent.EndsWith("..."))
            {
                return SentenceType.NotEnded;
            }
            else return SentenceType.Invalid;
        }
        public void Delete(Word word)
        {
            this.words.Remove(word);
        }
        public void Create(Word word)
        {
            this.words.Add(word);
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
