using System;
using System.Collections.Generic;

namespace Dissected.Structure
{
    public class ListColumn : Column
    {
        private readonly IList<string> Texts;

        public ListColumn(int capacity)
        {
            Texts = new string[capacity];
        }

        public override void Write(int row, string text)
        {
            if (row >= Texts.Count)
            {
                throw new IndexOutOfRangeException();
            }
            Texts[row] = text;
        }

        public override string Read(int row)
        {
            if (row >= Texts.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return Texts[row];
        }
    }
}