using System;
using System.Collections.Generic;
using Dissected.Structure;
using NUnit.Framework;

namespace Dissected.Tests.Structure
{
    [TestFixture]
    public class ListColumnTests
    {
        private ListColumn Column;

        [SetUp]
        public void Setup()
        {
            var texts = new List<string> {"", ""};
            Column = new ListColumn(texts);
        }

        [Test]
        public void WriteOneRow_ReadSameRowReturnsSameValue()
        {
            // Act
            Column.Write(0, "Test value");
            string result = Column.Read(0);

            // Assert
            Assert.AreEqual(result, "Test value");
        }

        [Test]
        public void WriteOneRow_ReadDifferentRowReturnsDifferentValue()
        {
            // Act
            Column.Write(0, "Test value");
            string result = Column.Read(1);

            // Assert
            Assert.AreNotEqual(result, "Test value");
        }

        [Test]
        public void WriteBeyondCapacity_ThrowsException()
        {
            // Act and Assert
            Assert.Catch<IndexOutOfRangeException>(() =>
            {
                Column.Write(2, "Test value");
            });
        }

        [Test]
        public void ReadBeyondCapacity_ThrowsException()
        {
            // Act and Assert
            Assert.Catch<IndexOutOfRangeException>(() =>
            {
                Column.Read(2);
            });
        }
    }
}
