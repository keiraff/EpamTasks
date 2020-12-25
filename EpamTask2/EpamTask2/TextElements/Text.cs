using EpamTask2.Parsers;
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
            //this.sentences.Sort(new SentComparer());
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

        public string FindWordsInSpecificSentences(SentenceType type, int wordLength)
        {
            StringBuilder sb = new StringBuilder();
            List<string> requestedWords = new List<string>();
            foreach (Sentence sent in this.sentences)
            {
                if (sent.TypeOfSentence == type)
                {
                    foreach (Word word in sent.Words)
                    {
                        if (word.Letters.Count == wordLength && requestedWords.IndexOf(word.Value) == -1)
                        {
                            requestedWords.Add(word.Value);
                        }
                    }
                }
            }
            if (requestedWords.Count == 0)
            {
                return $"There is no words with {wordLength} length or no {type} sentences.";
            }
            else
            {
                sb.Append($"Words with length {wordLength} from {type} sentences: "+Environment.NewLine);
                foreach (string item in requestedWords)
                {
                    sb.Append(item+Environment.NewLine);
                }
                return sb.ToString();
            }
        }
        public Text DeleteAllWordsStartingWithConsonant(int wordLength)
        {
            TextParser parser = new TextParser();
            for (int j = 0; j < this.Sentences.Count; j++)
            {
                List<Sentence> listOfSentence = this.Sentences as List<Sentence>;
                int temp = listOfSentence[j].Words.Count;
                List<Word> listOfWords = listOfSentence[j].Words as List<Word>;
                for (int i = 0; i < temp; i++)
                {
                    
                    if ((!listOfWords[i].IsFirstLetterVowel) && (listOfWords[i].Value.Length == wordLength))
                    {
                        (this.Sentences as List<Sentence>)[j].Words.Remove(listOfWords[i]);
                        i--;
                        temp--;
                    }
                    else continue;
                }
                (this.Sentences as List<Sentence>)[j] = parser.SentenceReparse((this.Sentences as List<Sentence>)[j].Words);
            }
            Text text = parser.TextReparse(this.Sentences);
            return text;
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
