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
            IColumn column = Substitute.For<IColumn>();

            // Act
            Document.AddColumn(column);

            // Assert
            Assert.AreEqual(1, Document.TotalColumns);
        }

        [Test]
        public void AddColumnWithOneRow_ReportsOneRow()
        {
            // Arrange
            IColumn column = Substitute.For<IColumn>();
            column.TotalRows.Returns(1);

            // Act
            Document.AddColumn(column);

            // Assert
            Assert.AreEqual(1, Document.TotalRows);
        }

        [Test]
        public void AddTwoColumnsWithDifferentRowCount_ReportsLargestRowCount()
        {
            // Arrange
            IColumn column1 = Substitute.For<IColumn>();
            column1.TotalRows.Returns(1);
            IColumn column2 = Substitute.For<IColumn>();
            column2.TotalRows.Returns(2);

            // Act
            Document.AddColumn(column1);
            Document.AddColumn(column2);

            // Assert
            Assert.AreEqual(2, Document.TotalRows);
        }

        [Test]
        public void Write_CallsColumnWrite()
        {
            // Arrange
            IColumn column = Substitute.For<IColumn>();
            Document.AddColumn(column);

            // Act
            Document.Write(0, 0, "Test value");

            // Assert
            column.Received(1).Write(0, "Test value");
        }

        [Test]
        public void WriteBeyondCapacity_ThrowsException()
        {
            // Arrange
            IColumn column = Substitute.For<IColumn>();
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
            IColumn column = Substitute.For<IColumn>();
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
            IColumn column = Substitute.For<IColumn>();
            Document.AddColumn(column);

            // Act and Assert
            Assert.Catch<IndexOutOfRangeException>(() =>
            {
                Document.Read(0, 1);
            });
        }
    }
}
