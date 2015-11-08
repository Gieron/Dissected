using Dissected.Decomposition;
using NUnit.Framework;

namespace Dissected.Tests.Decomposition
{
    [TestFixture]
    public class LcsFinderTests
    {
        private LcsFinder Finder;

        [SetUp]
        public void Setup()
        {
            Finder = new LcsFinder();
        }

        [TestCase("", "", "")]
        [TestCase(null, "", "")]
        [TestCase("", null, "")]
        [TestCase(null, null, "")]
        [TestCase("ABCDEFGH", "", "")]
        [TestCase("", "ABCDEFGH", "")]
        [TestCase("ABCDEFGH", "ABCDEFGH", "ABCDEFGH")]
        [TestCase("ABCDEFGH", "IJKLMN", "")]
        [TestCase("ABCDEFGH", "ABCDEFGHIJKLMN", "ABCDEFGH")]
        [TestCase("ABCDEFGH", "XYZEFGHIJKLMN", "EFGH")]
        [TestCase("IJKLMN", "ABCDEFGHIJKLMN", "IJKLMN")]
        [TestCase("A B C D E F G H", "ABCDEFGH", "A")]
        [TestCase("A B C DE F G H", "ABCDEFGH", "DE")]
        [TestCase("A AB ABC", "ABC", "ABC")]
        [TestCase("ABC AB A", "ABC", "ABC")]
        public void FindLcsForTowStrings_ReturnsLongestCommonSubstring(string a, string b, string e)
        {
            // Act
            string result = Finder.FindLongestCommonSubstring(a, b);

            // Assert
            Assert.AreEqual(result, e);
        }
    }
}
