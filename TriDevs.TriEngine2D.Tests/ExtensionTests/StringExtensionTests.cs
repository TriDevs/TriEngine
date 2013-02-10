using NUnit.Framework;
using TriDevs.TriEngine2D.Extensions;

namespace TriDevs.TriEngine2D.Tests.ExtensionTests
{
    [TestFixture]
    public class StringExtensionTests
    {
        private const string TestString = "Foo Bar Baz";
        private const string FooString = "Foo Foo Foo";

        [Test]
        public void ReplaceFirstTest()
        {
            const string expected = "Bar Bar Baz";
            Assert.AreEqual(TestString.ReplaceFirst("Foo", "Bar"), expected);
            Assert.AreNotEqual(TestString.ReplaceFirst("foo", "Bar"), expected);
            Assert.AreEqual(TestString.ReplaceFirst("Foo", "Bar", true), expected);
            Assert.AreEqual(TestString.ReplaceFirst("foo", "Bar", true), expected);
        }

        [Test]
        public void ReplaceTest()
        {
            const string expectedAll = "Bar Bar Bar";
            const string expectedNumber = "Bar Bar Foo";
            Assert.AreEqual(FooString.Replace("Foo", "Bar", false), expectedAll);
            Assert.AreNotEqual(FooString.Replace("foo", "Bar", false), expectedAll);
            Assert.AreEqual(FooString.Replace("foo", "Bar", true), expectedAll);
            Assert.AreEqual(FooString.Replace("Foo", "Bar", 2), expectedNumber);
            Assert.AreNotEqual(FooString.Replace("foo", "Bar", 2), expectedNumber);
            Assert.AreEqual(FooString.Replace("Foo", "Bar", 2, true), expectedNumber);
            Assert.AreEqual(FooString.Replace("foo", "Bar", 2, true), expectedNumber);
        }
    }
}
