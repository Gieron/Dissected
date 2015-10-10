namespace Dissected.Structure
{
    public abstract class Column
    {
        public abstract int TotalRows { get; }
        public abstract void Write(int row, string text);
        public abstract string Read(int row);
    }
}
