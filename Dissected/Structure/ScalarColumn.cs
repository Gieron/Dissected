namespace Dissected.Structure
{
    public class ScalarColumn : IColumn
    {
        private string Text;

        public ScalarColumn(string text)
        {
            Text = text;
        }

        public int TotalRows => 1;

        public void Write(int row, string text)
        {
            Text = text;
        }

        public string Read(int row)
        {
            return Text;
        }
    }
}
