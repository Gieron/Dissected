using System.Collections.Generic;

namespace Dissected.Structure
{
    public interface IColumnFactory
    {
        IColumn CreateListColumn(IEnumerable<string> texts);
        IColumn CreateScalarColumn(string text);
    }
}