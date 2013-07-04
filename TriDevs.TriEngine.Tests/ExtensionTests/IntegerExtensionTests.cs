using System;
using NUnit.Framework;
using TriDevs.TriEngine.Extensions;

namespace TriDevs.TriEngine.Tests.ExtensionTests
{
    [TestFixture]
    public class IntegerExtensionTests
    {
        [Test]
        public void ShouldNotClampInt16()
        {
            Assert.AreEqual(((Int16) 5).Clamp(0, 10), 5);
        }

        [Test]
        public void ShouldNotClampUInt16()
        {
            Assert.AreEqual(((UInt16) 5).Clamp(0, 10), 5);
        }

        [Test]
        public void ShouldNotClampInt32()
        {
            Assert.AreEqual(5.Clamp(0, 10), 5);
        }

        [Test]
        public void ShouldNotClampUInt32()
        {
            Assert.AreEqual(((UInt32) 5).Clamp(0, 10), 5);
        }

        [Test]
        public void ShouldNotClampInt64()
        {
            Assert.AreEqual(((Int64) 5).Clamp(0, 10), 5);
        }

        [Test]
        public void ShouldNotClampUInt64()
        {
            Assert.AreEqual(((UInt64) 5).Clamp(0, 10), 5);
        }

        [Test]
        public void ShouldClampInt16ToMinimum()
        {
            Assert.AreEqual(((Int16) 0).Clamp(5, 10), 5);
        }

        [Test]
        public void ShouldClampUInt16ToMinimum()
        {
            Assert.AreEqual(((UInt16) 0).Clamp(5, 10), 5);
        }

        [Test]
        public void ShouldClampInt32ToMinimum()
        {
            Assert.AreEqual(0.Clamp(5, 10), 5);
        }

        [Test]
        public void ShouldClampUInt32ToMinimum()
        {
            Assert.AreEqual(((UInt32) 0).Clamp(5, 10), 5);
        }

        [Test]
        public void ShouldClampInt64ToMinimum()
        {
            Assert.AreEqual(((Int64) 0).Clamp(5, 10), 5);
        }

        [Test]
        public void ShouldClampUInt64ToMinimum()
        {
            Assert.AreEqual(((UInt64) 0).Clamp(5, 10), 5);
        }

        [Test]
        public void ShouldClampInt16ToMaximum()
        {
            Assert.AreEqual(((Int16) 10).Clamp(0, 5), 5);
        }

        [Test]
        public void ShouldClampUInt16ToMaximum()
        {
            Assert.AreEqual(((UInt16) 10).Clamp(0, 5), 5);
        }

        [Test]
        public void ShouldClampInt32ToMaximum()
        {
            Assert.AreEqual(10.Clamp(0, 5), 5);
        }

        [Test]
        public void ShouldClampUInt32ToMaximum()
        {
            Assert.AreEqual(((UInt32) 10).Clamp(0, 5), 5);
        }

        [Test]
        public void ShouldClampInt64ToMaximum()
        {
            Assert.AreEqual(((Int64) 10).Clamp(0, 5), 5);
        }

        [Test]
        public void ShouldClampUInt64ToMaximum()
        {
            Assert.AreEqual(((UInt64) 10).Clamp(0, 5), 5);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Int16ClampShouldThrowArgumentException()
        {
            ((Int16) 0).Clamp(10, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void UInt16ClampShouldThrowArgumentException()
        {
            ((UInt16) 0).Clamp(10, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Int32ClampShouldThrowArgumentException()
        {
            0.Clamp(10, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void UInt32ClampShouldThrowArgumentException()
        {
            ((UInt32) 0).Clamp(10, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Int64ClampShouldThrowArgumentException()
        {
            ((Int64) 0).Clamp(10, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void UInt64ClampShouldThrowArgumentException()
        {
            ((UInt64) 0).Clamp(10, 0);
        }

    }
}
