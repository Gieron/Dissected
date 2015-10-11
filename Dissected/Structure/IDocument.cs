namespace Dissected.Structure
{
    public interface IDocument
    {
        int TotalRows { get; }
        int TotalColumns { get; }
        void AddColumn(IColumn column);
        void Write(int row, int column, string text);
        string Read(int row, int column);
    }
}