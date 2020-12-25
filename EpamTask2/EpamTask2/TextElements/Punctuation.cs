using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask2.TextElements
{
    internal class Punctuation
    {
        private List<String> punctuationMarks;
        public List<String> PunctuationMarks { get => punctuationMarks; private set => punctuationMarks = value; }
        public Punctuation()
        {
            punctuationMarks = new List<string>();
        }
        public string Value
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var mark in this.PunctuationMarks)
                {
                    sb.Append(mark);
                }
                return sb.ToString();

            }
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
