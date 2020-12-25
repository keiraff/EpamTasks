using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace EpamTask2.TextElements
{
    internal class Separators
    {
        private string[] sentenceSeparators = new string[] { "?", "!", ".", "...", "?!" };
        private string sentenceSeparatorsRegEx = @"(!|\?!|\.+|\?)" ;
        private char[] prepunctuationMarks = new char[] { '(', '"', '[', '{', '№' /* "(", "\"", "[", "{", "№" */};
        private char[] punctuationMarks = new char[] { ',', ';', ':', '.', '!', '?', ')', '"', '}', ']', '%'/*",", ";", ":", ".", "!", "?", ")", "\"", "}", "]", "%" */};
        public string SentenceSeparatorsRegEx
        {
            get => sentenceSeparatorsRegEx;
        }
        public IEnumerable<char> PrepunctuationMarks()
        {
            return prepunctuationMarks.AsEnumerable();
        }

        public IEnumerable<char> PunctuationMarks()
        {
            return punctuationMarks.AsEnumerable();
        }
        public IEnumerable<string> SentenceSeparators()
        {
            return sentenceSeparators.AsEnumerable();
        }
        

    }
}
