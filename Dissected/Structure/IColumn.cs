using System;

namespace Dissected.Structure
{
    public interface IColumn
    {
        int TotalRows { get; }
        void Write(int row, string text);
        string Read(int row);
    }
}
