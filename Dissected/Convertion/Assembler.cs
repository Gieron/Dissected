using System.IO;
using System.Text;
using Dissected.Structure;

namespace Dissected.Convertion
{
    public static class Assembler
    {
        /// <summary>
        /// Writes the document to stream in UTF-8 without BOM.
        /// The stream is NOT closed.
        /// </summary>
        public static void Assemble(IDocument document, Stream stream)
        {
            if(document.TotalRows == 0 || document.TotalColumns == 0)
            {
                return;
            }

            // The default buffer size is 4KiB, so I'm using that
            using(var writer = new StreamWriter(stream, new UTF8Encoding(false), 4096, true))
            {
                for(int row = 0; row < document.TotalRows; row++)
                {
                    for(int column = 0; column < document.TotalColumns; column++)
                    {
                        writer.Write(document.Read(row, column));
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
