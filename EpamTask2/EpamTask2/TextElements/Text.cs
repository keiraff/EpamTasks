using System;
using System.Collections.Generic;
using System.Linq;
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
        public Text(ICollection<Sentence> collectionOfSntences)
        {
            Sentences = collectionOfSntences;
        }
        public List<Sentence> SortByNumberOfWords()
        {
            List<Sentence> sortedList=new List<Sentence>();
            var sortedListOfSentences = ((this.Sentences).OrderBy(x => x.GetAmountOfWords));
            foreach (var item in sortedListOfSentences)
            {
                sortedList.Add(item);
            }
            return sortedList;
            //return sortedListOfSentences as List<Sentence>;
            //this.sentences.Sort(new SentComparer());
            //this.PrintSortedText();
        }
        public string PrintSortedText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var sentence in this.SortByNumberOfWords())
            {
                sb.Append("(" + sentence.Words.Count + ") " + sentence.Value.Trim());
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var sentence in sentences)
            {
                if ((Sentences as List<Sentence>).IndexOf(sentence) == Sentences.Count - 1)
                {
                    sb.Append(sentence.Value);
                }
                sb.Append(sentence.ToString()+" ");
            }
            return sb.ToString();
        }
    }
}
