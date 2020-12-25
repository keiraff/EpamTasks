using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask2.TextElements
{
    internal class Word:ISentenceElement
    {
        private List<Char> letters;
        private Punctuation prepunctuation;
        private Punctuation punctuation;
        private int lineNumber;
        public List<Char> Letters { get => letters;private set => letters = value; }
        public int LineNumberOfWord { get => lineNumber; private set => lineNumber=value; }
        public Punctuation Prepunctuation { get => prepunctuation; }
        public Punctuation Punctuation { get => punctuation; }
        public string SentenceElementValue
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(prepunctuation.Value);
                foreach (var s in this.letters)
                {
                    sb.Append(s);
                }
                sb.Append(punctuation.Value);
                return sb.ToString();
            }
        }
        public string Value
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var s in this.Letters)
                {
                    sb.Append(s);
                }
                return sb.ToString();
            }
        }
        public Word()
        {
            this.letters = new List<Char>();
        }
        public Word(int lineNumber)
        { 
            LineNumberOfWord = lineNumber;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
