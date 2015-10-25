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
        private Parser Parser;
        private IDocument Document;
        private IColumnFactory Factory;

        [SetUp]
        public void Setup()
        {
            Document = Substitute.For<IDocument>();
            Factory = Substitute.For<IColumnFactory>();
            Parser = new Parser(Factory);
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
            Factory.Received(1).CreateScalarColumn("ABC");
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
            Factory.Received(1).CreateScalarColumn("ABC");
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
            Factory.Received(1).CreateListColumn(new List<string> {"ABC", "CDF"});
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
            Factory.Received(1).CreateScalarColumn("ABC");
            Factory.Received(1).CreateListColumn(new List<string> {"CDF", "GHI"});
            Factory.Received(1).CreateScalarColumn("JKL");
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
            Factory.Received(1).CreateScalarColumn("ABC");
            Factory.Received(1).CreateListColumn(new List<string> {"", "GHIJKL MNOPQRS", "WXYZ"});
            Factory.Received(1).CreateScalarColumn("TUV");
        }
    }
}
