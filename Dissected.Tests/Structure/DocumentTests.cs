using System;
using Dissected.Structure;
using NSubstitute;
using NUnit.Framework;

namespace Dissected.Tests.Structure
{
    [TestFixture]
    public class DocumentTests
    {
        private Document Document;

        [SetUp]
        public void Setup()
        {
            Document = new Document();
        }

        [Test]
        public void AddOneColumn_ReportsOneColumn()
        {
            // Arrange
            Column column = Substitute.For<Column>();

            // Act
            Document.AddColumn(column);

            // Assert
            Assert.AreEqual(Document.TotalColumns, 1);
        }

        [Test]
        public void AddColumnWithOneRow_ReportsOneRow()
        {
            // Arrange
            Column column = Substitute.For<Column>();
            column.TotalRows.Returns(1);

            // Act
            Document.AddColumn(column);

            // Assert
            Assert.AreEqual(Document.TotalRows, 1);
        }

        [Test]
        public void AddTwoColumnsWithDifferentRowCount_ReportsLargestRowCount()
        {
            // Arrange
            Column column1 = Substitute.For<Column>();
            column1.TotalRows.Returns(1);
            Column column2 = Substitute.For<Column>();
            column2.TotalRows.Returns(2);

            // Act
            Document.AddColumn(column1);
            Document.AddColumn(column2);

            // Assert
            Assert.AreEqual(Document.TotalRows, 2);
        }

        [Test]
        public void Write_CallsColumnWrite()
        {
            // Arrange
            Column column = Substitute.For<Column>();
            Document.AddColumn(column);

            // Act
            Document.Write(0, 0, "Test value");

            // Assert
            column.Received().Write(0, "Test value");
        }

        [Test]
        public void WriteBeyondCapacity_ThrowsException()
        {
            // Arrange
            Column column = Substitute.For<Column>();
            Document.AddColumn(column);

            // Act and Assert
            Assert.Catch<IndexOutOfRangeException>(() =>
            {
                Document.Write(0, 1, "Test value");
            });
        }

        [Test]
        public void Read_CallsColumnRead()
        {
            // Arrange
            Column column = Substitute.For<Column>();
            Document.AddColumn(column);

            // Act
            Document.Read(0, 0);

            // Assert
            column.Received().Read(0);
        }

        [Test]
        public void ReadBeyondCapacity_ThrowsException()
        {
            // Arrange
            Column column = Substitute.For<Column>();
            Document.AddColumn(column);

            // Act and Assert
            Assert.Catch<IndexOutOfRangeException>(() =>
            {
                Document.Read(0, 1);
            });
        }
    }
}
