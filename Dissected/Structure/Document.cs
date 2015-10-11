using System;
using System.Collections.Generic;
using System.Linq;

namespace Dissected.Structure
{
    public class Document : IDocument
    {
        private readonly IList<IColumn> Columns;

        public Document()
        {
            TotalRows = 0;
            Columns = new List<IColumn>();
        }

        public int TotalRows { get; private set; }
        public int TotalColumns => Columns.Count;

        public void AddColumn(IColumn column)
        {
            if(column.TotalRows > TotalRows)
            {
                TotalRows = column.TotalRows;
            }
            Columns.Add(column);
        }

        public void Write(int row, int column, string text)
        {
            if(column >= TotalColumns)
            {
                throw new IndexOutOfRangeException();
            }
            Columns.ElementAt(column).Write(row, text);
        }

        public string Read(int row, int column)
        {
            if(column >= TotalColumns)
            {
                throw new IndexOutOfRangeException();
            }
            return Columns.ElementAt(column).Read(row);
        }
    }
}
