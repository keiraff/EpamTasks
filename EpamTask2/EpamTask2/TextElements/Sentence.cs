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
    internal class Sentence//:IEditable<Word>
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
                foreach (var w in this.Words)
                {
                    sb.Append(w.SentenceElementValue+" ");
                }
                return sb.ToString();
            }
        }
        public Sentence()
        {
            words = new List<Word>();
        }
        public Sentence(string value)
        {
            words = new List<Word>();
            TypeOfSentence = GetTypeOfSentence(value);
            Length = value.Length;
            //Value = value;
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
        public override string ToString()
        {
            return Value;
        }
    }
}
