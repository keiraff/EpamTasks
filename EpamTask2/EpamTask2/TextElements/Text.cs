using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask2.TextElements
{
    internal class Text
    {
        private List<Sentence> sentences;
        public List<Sentence> Sentences { get => sentences; private set => sentences = value; }
    }
}
