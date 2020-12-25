using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask2.TextElements
{
    internal class Text
    {
        private ICollection<Sentence> sentences;
        public ICollection<Sentence> Sentences { get => sentences; private set => sentences = value; }
        public Text()
        {
            Sentences= new List<Sentence>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var sentence in sentences)
            {
                sb.Append(sentence.ToString());
            }
            return sb.ToString();
        }
    }
}
