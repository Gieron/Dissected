using Dissected.Structure;
using NUnit.Framework;

namespace Dissected.Tests.Structure
{
    [TestFixture]
    public class ScalarColumnTests
    {
        private ScalarColumn Column;

        [SetUp]
        public void Setup()
        {
            Column = new ScalarColumn("");
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
        public void WriteOneRow_ReadDifferentRowReturnsSameValue()
        {
            // Act
            Column.Write(0, "Test value");
            string result = Column.Read(1);

            // Assert
            Assert.AreEqual(result, "Test value");
        }
    }
}
