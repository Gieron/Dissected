using System.IO;
using Dissected.Convertion;
using Dissected.Structure;
using NSubstitute;
using NUnit.Framework;

namespace Dissected.Tests.Convertion
{
    [TestFixture]
    public class AssemblerTests
    {
        private IDocument Document;
        private Stream Stream;

        [SetUp]
        public void Setup()
        {
            Document = Substitute.For<IDocument>();
            Stream = new MemoryStream();
        }

        private string GetResultFromStream()
        {
            Stream.Seek(0, 0);
            return new StreamReader(Stream).ReadToEnd();
        }

        [Test]
        public void AssembleOneRowOneColumn_YieldsOneRow()
        {
            // Arrange
            Document.TotalRows.Returns(1);
            Document.TotalColumns.Returns(1);
            Document.Read(0, 0).Returns("ABC");

            // Act
            Assembler.Assemble(Document, Stream);

            // Assert
            Assert.AreEqual(@"ABC
", GetResultFromStream());
        }

        [Test]
        public void AssembleOneRowMultipleColumns_YieldsOneRow()
        {
            // Arrange
            Document.TotalRows.Returns(1);
            Document.TotalColumns.Returns(2);
            Document.Read(0, 0).Returns("ABC");
            Document.Read(0, 1).Returns("DEF");

            // Act
            Assembler.Assemble(Document, Stream);

            // Assert
            Assert.AreEqual(@"ABCDEF
", GetResultFromStream());
        }

        [Test]
        public void AssembleMultipleRowsOneColumn_YieldMultipleRows()
        {
            // Arrange
            Document.TotalRows.Returns(2);
            Document.TotalColumns.Returns(1);
            Document.Read(0, 0).Returns("ABC");
            Document.Read(1, 0).Returns("DEF");

            // Act
            Assembler.Assemble(Document, Stream);

            // Assert
            Assert.AreEqual(@"ABC
DEF
", GetResultFromStream());
        }

        [Test]
        public void AssembleMultipleRowsMultipleColumns_YieldMultipleRows()
        {
            // Arrange
            Document.TotalRows.Returns(2);
            Document.TotalColumns.Returns(2);
            Document.Read(0, 0).Returns("ABC");
            Document.Read(0, 1).Returns("DEF");
            Document.Read(1, 0).Returns("GHI");
            Document.Read(1, 1).Returns("JKL");

            // Act
            Assembler.Assemble(Document, Stream);

            // Assert
            Assert.AreEqual(@"ABCDEF
GHIJKL
", GetResultFromStream());
        }

        [Test]
        public void AssembleZeroRows_YieldsEmptyText()
        {
            // Arrange
            Document.TotalRows.Returns(0);
            Document.TotalColumns.Returns(1);

            // Act
            Assembler.Assemble(Document, Stream);

            // Assert
            Assert.AreEqual(@"", GetResultFromStream());
        }

        [Test]
        public void AssembleZeroColumns_YieldsEmptyText()
        {
            // Arrange
            Document.TotalRows.Returns(1);
            Document.TotalColumns.Returns(0);

            // Act
            Assembler.Assemble(Document, Stream);

            // Assert
            Assert.AreEqual(@"", GetResultFromStream());
        }
    }
}
