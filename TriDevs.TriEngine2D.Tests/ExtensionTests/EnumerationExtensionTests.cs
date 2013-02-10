using System;
using NUnit.Framework;
using TriDevs.TriEngine2D.Extensions;

namespace TriDevs.TriEngine2D.Tests.ExtensionTests
{
    [TestFixture]
    public class EnumerationExtensionTests
    {
        [Flags]
        private enum Enum
        {
            Foo = 1,
            Bar = 2,
        }

        [Flags]
        private enum LongEnum : long
        {
            Foo = 0x80000000,
            Bar = 0x100000000,
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void HasStringTest()
        {
            Enum.Foo.Has("string");
        }

        [Test]
        public void HasTest()
        {
            Assert.True(Enum.Foo.Has(Enum.Foo));
        }

        [Test]
        public void MissingTest()
        {
            Assert.True(Enum.Bar.Missing(Enum.Foo));
        }

        [Test]
        public void IncludeTest()
        {
            var val = Enum.Foo;
            val = val.Include(Enum.Bar);
            Assert.True(val.Has(Enum.Foo));
            Assert.True(val.Has(Enum.Bar));
        }

        [Test]
        public void RemoveTest()
        {
            var val = Enum.Foo.Include(Enum.Bar);
            val = val.Remove(Enum.Foo);
            Assert.True(val.Has(Enum.Bar));
            Assert.True(val.Missing(Enum.Foo));
        }

        [Test]
        public void HasLongTest()
        {
            Assert.True(LongEnum.Foo.Has(LongEnum.Foo));
        }

        [Test]
        public void MissingLongTest()
        {
            Assert.True(LongEnum.Bar.Missing(LongEnum.Foo));
        }

        [Test]
        public void IncludeLongTest()
        {
            var val = LongEnum.Foo;
            val = val.Include(LongEnum.Bar);
            Assert.True(val.Has(LongEnum.Foo));
            Assert.True(val.Has(LongEnum.Bar));
        }

        [Test]
        public void RemoveLongTest()
        {
            var val = LongEnum.Foo.Include(LongEnum.Bar);
            val = val.Remove(LongEnum.Foo);
            Assert.True(val.Has(LongEnum.Bar));
            Assert.True(val.Missing(LongEnum.Foo));
        }
    }
}
