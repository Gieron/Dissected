using System.Collections.Generic;
using System.Linq;
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
        public void FindLongestCommonSubstring_ReturnsLongestCommonSubstring(string a, string b, string e)
        {
            // Act
            string result = Finder.FindLongestCommonSubstring(a, b);

            // Assert
            Assert.AreEqual(e, result);
        }

        [TestCase("", "", new string[] {})]
        [TestCase(null, "", new string[] {})]
        [TestCase("", null, new string[] {})]
        [TestCase(null, null, new string[] {})]
        [TestCase("ABCDEFGH", "", new string[] {})]
        [TestCase("", "ABCDEFGH", new string[] {})]
        [TestCase("ABCDEFGH", "IJKLMN", new string[] {})]
        [TestCase("ABCDEFGH", "ABCDEFGH", new [] {"ABCDEFGH"})]
        [TestCase("ABCXXFGH", "ABCYYFGH", new [] {"ABC", "FGH"})]
        [TestCase("ABCYYFGH", "FGHXXABC", new [] {"ABC"})]
        [TestCase("ABCXXFGHYYIJK", "ABCYYFGHIJK", new [] {"ABC", "FGH", "IJK"})]
        [TestCase("A B C D E F G H", "ABCDEFGH", new [] {"A", "B", "C", "D", "E", "F", "G", "H"})]
        [TestCase("A B C DE F G H", "ABCDEFGH", new [] {"A", "B", "C", "DE", "F", "G", "H"})]
        public void FindAllCommonSubstringsFor_ReturnsAllCommonSubstrings(string a, string b, IEnumerable<string> e)
        {
            // Act
            IEnumerable<string> result = Finder.FindAllCommonSubstrings(a, b);

            // Assert
            Assert.IsTrue(e.SequenceEqual(result));
        }
    }
}
