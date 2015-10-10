namespace Dissected.Structure
{
    public class ScalarColumn : Column
    {
        private string Text;

        public ScalarColumn(string text)
        {
            Text = text;
        }

        public override int TotalRows => 1;

        public override void Write(int row, string text)
        {
            Text = text;
        }

        public override string Read(int row)
        {
            return Text;
        }
    }
}
