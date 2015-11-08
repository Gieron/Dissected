using System.IO;
using System.Text;
using Dissected.Structure;

namespace Dissected.Convertion
{
    public class Parser
    {
        private readonly IColumnFactory Factory;

        public Parser(IColumnFactory factory)
        {
            Factory = factory;
        }

        public void Parse(Stream stream, IDocument document)
        {
            using(var reader = new StreamReader(stream, Encoding.UTF8, true, 4096, true))
            {
                if(!reader.EndOfStream)
                {
                    string text = reader.ReadLine();
                    document.AddColumn(Factory.CreateScalarColumn(text));
                }

                while(!reader.EndOfStream)
                {
                    string text = reader.ReadLine();
                }
            }
        }
    }
}
