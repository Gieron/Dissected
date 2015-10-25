using System.Collections.Generic;

namespace Dissected.Structure
{
    public class ColumnFactory : IColumnFactory
    {
        public IColumn CreateScalarColumn(string text)
        {
            return new ScalarColumn(text);
        }

        public IColumn CreateListColumn(IEnumerable<string> texts)
        {
            return new ListColumn(texts);
        }
    }
}
