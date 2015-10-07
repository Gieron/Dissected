namespace Dissected.Structure
{
    public class ScalarColumn : Column
    {
        private string Text;

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
