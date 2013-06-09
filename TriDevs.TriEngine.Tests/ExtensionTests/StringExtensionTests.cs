using NUnit.Framework;
using TriDevs.TriEngine.Extensions;

namespace TriDevs.TriEngine.Tests.ExtensionTests
{
    [TestFixture]
    public class StringExtensionTests
    {
        private const string TestString = "Foo Bar Baz";
        private const string FooString = "Foo Foo Foo";

        [Test]
        public void ReplaceFirstCaseSensitive()
        {
            const string expected = "Bar Bar Baz";
            Assert.AreEqual(TestString.ReplaceFirst("Foo", "Bar"), expected);
            Assert.AreNotEqual(TestString.ReplaceFirst("foo", "Bar"), expected);
        }

        [Test]
        public void ReplaceFirstCaseInsensitive()
        {
            const string expected = "Bar Bar Baz";
            Assert.AreEqual(TestString.ReplaceFirst("Foo", "Bar", true), expected);
            Assert.AreEqual(TestString.ReplaceFirst("foo", "Bar", true), expected);
        }

        [Test]
        public void ReplaceAllCaseSensitive()
        {
            const string expected = "Bar Bar Bar";
            Assert.AreEqual(FooString.Replace("Foo", "Bar", false), expected);
            Assert.AreNotEqual(FooString.Replace("foo", "Bar", false), expected);
        }

        [Test]
        public void ReplaceAllCaseInsensitive()
        {
            const string expected = "Bar Bar Bar";
            Assert.AreEqual(FooString.Replace("Foo", "Bar", true), expected);
            Assert.AreEqual(FooString.Replace("foo", "Bar", true), expected);
        }

        [Test]
        public void ReplaceTwoOccurrencesCaseSensitive()
        {
            const string expected = "Bar Bar Foo";
            Assert.AreEqual(FooString.Replace("Foo", "Bar", 2), expected);
            Assert.AreNotEqual(FooString.Replace("foo", "Bar", 2), expected);
        }

        [Test]
        public void ReplaceTwoOccurrencesCaseInsensitive()
        {
            const string expected = "Bar Bar Foo";
            Assert.AreEqual(FooString.Replace("Foo", "Bar", 2, true), expected);
            Assert.AreEqual(FooString.Replace("foo", "Bar", 2, true), expected);
        }
    }
}
