using System.Collections.Generic;
using Dissected.Structure;
using NUnit.Framework;

namespace Dissected.Tests.Structure
{
    [TestFixture]
    public class ColumnFactoryTests
    {
        private ColumnFactory Factory;

        [SetUp]
        public void Setup()
        {
            Factory = new ColumnFactory();
        }

        [Test]
        public void CreateScalarColumn_ReturnsScalarColumn()
        {
            // Act
            IColumn column = Factory.CreateScalarColumn("Test value");

            // Assert
            Assert.IsTrue(column is ScalarColumn);
        }

        [Test]
        public void CreateListColumn_ReturnsListColumn()
        {
            // Act
            IColumn column = Factory.CreateListColumn(new List<string>());

            // Assert
            Assert.IsTrue(column is ListColumn);
        }
    }
}
