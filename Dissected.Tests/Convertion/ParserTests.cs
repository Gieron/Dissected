using System.Collections.Generic;
using System.IO;
using System.Text;
using Dissected.Convertion;
using Dissected.Structure;
using NSubstitute;
using NUnit.Framework;

namespace Dissected.Tests.Convertion
{
    [TestFixture]
    public class ParserTests
    {
        private IDocument Document;

        [SetUp]
        public void Setup()
        {
            Document = Substitute.For<IDocument>();
        }

        private static Stream ReadString(string text)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(text));
        }

        [Test]
        public void ParseOneRow_YieldsOneScalarColumn()
        {
            // Arrange
            const string text = @"ABC";

            // Act
            Parser.Parse(ReadString(text), Document);

            // Assert
            Document.Received(1).AddColumn(new ScalarColumn("ABC"));
        }

        [Test]
        public void ParseTwoIdenticalRows_YieldsOneScalarColumn()
        {
            // Arrange
            const string text = @"ABC
ABC";

            // Act
            Parser.Parse(ReadString(text), Document);

            // Assert
            Document.Received(1).AddColumn(new ScalarColumn("ABC"));
        }

        [Test]
        public void ParseTwoDifferentRows_YieldsOneListColumn()
        {
            // Arrange
            const string text = @"ABC
CDF";

            // Act
            Parser.Parse(ReadString(text), Document);

            // Assert
            Document.Received(1).AddColumn(new ListColumn(new List<string> {"ABC", "CDF"}));
        }

        [Test]
        public void ParseFixedLengthComplexRows_YieldsComplexColumns()
        {
            // Arrange
            const string text = @"ABC DEF JKL
ABC GHI JKL";

            // Act
            Parser.Parse(ReadString(text), Document);

            // Assert
            Document.Received(1).AddColumn(new ScalarColumn("ABC"));
            Document.Received(1).AddColumn(new ListColumn(new List<string> {"CDF", "GHI"}));
            Document.Received(1).AddColumn(new ScalarColumn("JKL"));
        }

        [Test]
        public void ParseVariableLengthComplexRows_YieldsComplexColumns()
        {
            // Arrange
            const string text = @"ABC TUV
ABC GHIJKL MNOPQRS TUV
ABC WXYZ TUV";

            // Act
            Parser.Parse(ReadString(text), Document);

            // Assert
            Document.Received(1).AddColumn(new ScalarColumn("ABC"));
            Document.Received(1).AddColumn(new ListColumn(new List<string> {"", "GHIJKL MNOPQRS", "WXYZ"}));
            Document.Received(1).AddColumn(new ScalarColumn("TUV"));
        }
    }
}
