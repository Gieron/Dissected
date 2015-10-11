using System;
using System.Collections.Generic;
using System.Linq;

namespace Dissected.Structure
{
    public class ListColumn : IColumn
    {
        private readonly IList<string> Texts;

        public ListColumn(IEnumerable<string> texts)
        {
            Texts = texts.ToList();
        }

        public int TotalRows => Texts.Count;

        public void Write(int row, string text)
        {
            if(row >= TotalRows)
            {
                throw new IndexOutOfRangeException();
            }
            Texts[row] = text;
        }

        public string Read(int row)
        {
            if(row >= TotalRows)
            {
                throw new IndexOutOfRangeException();
            }
            return Texts[row];
        }
    }
}