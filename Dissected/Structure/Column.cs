namespace Dissected.Structure
{
    public abstract class Column
    {
        public abstract void Write(int row, string text);
        public abstract string Read(int row);
    }
}
