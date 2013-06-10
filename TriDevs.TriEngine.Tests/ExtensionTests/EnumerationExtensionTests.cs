using System;
using NUnit.Framework;
using TriDevs.TriEngine.Extensions;

namespace TriDevs.TriEngine.Tests.ExtensionTests
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
        public void ShouldThrowExceptionOnString()
        {
            Enum.Foo.Has("string");
        }

        [Test]
        public void ShouldHaveValue()
        {
            Assert.True(Enum.Foo.Has(Enum.Foo));
        }

        [Test]
        public void ShouldNotHaveValue()
        {
            Assert.True(Enum.Bar.Missing(Enum.Foo));
        }

        [Test]
        public void ShouldIncludeValue()
        {
            var val = Enum.Foo;
            val = val.Include(Enum.Bar);
            Assert.True(val.Has(Enum.Foo));
            Assert.True(val.Has(Enum.Bar));
        }

        [Test]
        public void ShouldRemoveValue()
        {
            var val = Enum.Foo.Include(Enum.Bar);
            val = val.Remove(Enum.Foo);
            Assert.True(val.Has(Enum.Bar));
            Assert.True(val.Missing(Enum.Foo));
        }

        [Test]
        public void ShouldHaveLongValue()
        {
            Assert.True(LongEnum.Foo.Has(LongEnum.Foo));
        }

        [Test]
        public void ShouldNotHaveLongValue()
        {
            Assert.True(LongEnum.Bar.Missing(LongEnum.Foo));
        }

        [Test]
        public void ShouldIncludeLongValue()
        {
            var val = LongEnum.Foo;
            val = val.Include(LongEnum.Bar);
            Assert.True(val.Has(LongEnum.Foo));
            Assert.True(val.Has(LongEnum.Bar));
        }

        [Test]
        public void ShouldRemoveLongValue()
        {
            var val = LongEnum.Foo.Include(LongEnum.Bar);
            val = val.Remove(LongEnum.Foo);
            Assert.True(val.Has(LongEnum.Bar));
            Assert.True(val.Missing(LongEnum.Foo));
        }
    }
}
