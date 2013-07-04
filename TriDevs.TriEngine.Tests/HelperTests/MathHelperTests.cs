using System;
using NUnit.Framework;

namespace TriDevs.TriEngine.Tests.HelperTests
{
    [TestFixture]
    public class MathHelperTests
    {
        [Test]
        public void ShouldNotClampFloat()
        {
            Assert.AreEqual(Helpers.Math.Clamp(0.5f, 0.0f, 1.0f), 0.5f);
        }

        [Test]
        public void ShouldNotClampDouble()
        {
            Assert.AreEqual(Helpers.Math.Clamp(0.5, 0.0, 1.0), 0.5);
        }

        [Test]
        public void ShouldNotClampDecimal()
        {
            Assert.AreEqual(Helpers.Math.Clamp(0.5M, 0M, 1M), 0.5M);
        }

        [Test]
        public void ShouldNotClampInt16()
        {
            Assert.AreEqual(Helpers.Math.Clamp((short) 3, (short) 0, (short) 5), 3);
        }

        [Test]
        public void ShouldNotClampUInt16()
        {
            Assert.AreEqual(Helpers.Math.Clamp((ushort) 3, (ushort) 0, (ushort) 5), 3);
        }

        [Test]
        public void ShouldNotClampInt32()
        {
            Assert.AreEqual(Helpers.Math.Clamp(3, 0, 5), 3);
        }

        [Test]
        public void ShouldNotClampUInt32()
        {
            Assert.AreEqual(Helpers.Math.Clamp((uint) 3, 0, 5), 3);
        }

        [Test]
        public void ShouldNotClampInt64()
        {
            Assert.AreEqual(Helpers.Math.Clamp((long) 3, 0, 5), 3);
        }

        [Test]
        public void ShouldNotClampUInt64()
        {
            Assert.AreEqual(Helpers.Math.Clamp((ulong)3, 0, 5), 3);
        }

        [Test]
        public void ShouldNotClampByte()
        {
            Assert.AreEqual(Helpers.Math.Clamp((byte)3, (byte)0, (byte)5), 3);
        }

        [Test]
        public void ShouldClampFloatToMinimum()
        {
            Assert.AreEqual(Helpers.Math.Clamp(-1.5f, 0.0f, 1.0f), 0.0f);
        }

        [Test]
        public void ShouldClampDoubleToMinimum()
        {
            Assert.AreEqual(Helpers.Math.Clamp(-1.5, 0.0, 1.0), 0.0);
        }

        [Test]
        public void ShouldClampDecimalToMinimum()
        {
            Assert.AreEqual(Helpers.Math.Clamp(-1.5M, 0M, 1M), 0M);
        }

        [Test]
        public void ShouldClampInt16ToMinimum()
        {
            Assert.AreEqual(Helpers.Math.Clamp((short) -3, (short) 0, (short) 5), 0);
        }

        [Test]
        public void ShouldClampUInt16ToMinimum()
        {
            Assert.AreEqual(Helpers.Math.Clamp((ushort) 3, (ushort) 5, (ushort) 10), 5);
        }

        [Test]
        public void ShouldClampInt32ToMinimum()
        {
            Assert.AreEqual(Helpers.Math.Clamp(-3, 0, 5), 0);
        }

        [Test]
        public void ShouldClampUInt32ToMinimum()
        {
            Assert.AreEqual(Helpers.Math.Clamp((uint) 3, 5, 10), 5);
        }

        [Test]
        public void ShouldClampInt64ToMinimum()
        {
            Assert.AreEqual(Helpers.Math.Clamp((long) -3, 0, 5), 0);
        }

        [Test]
        public void ShouldClampUInt64ToMinimum()
        {
            Assert.AreEqual(Helpers.Math.Clamp((ulong) 3, 5, 10), 5);
        }

        [Test]
        public void ShouldClampByteToMinimum()
        {
            Assert.AreEqual(Helpers.Math.Clamp((byte) 3, (byte) 5, (byte) 10), 5);
        }

        [Test]
        public void ShouldClampFloatToMaximum()
        {
            Assert.AreEqual(Helpers.Math.Clamp(1.5f, 0.0f, 1.0f), 1.0f);
        }

        [Test]
        public void ShouldClampDoubleToMaximum()
        {
            Assert.AreEqual(Helpers.Math.Clamp(1.5, 0.0, 1.0), 1.0);
        }

        [Test]
        public void ShouldClampDecimalToMaximum()
        {
            Assert.AreEqual(Helpers.Math.Clamp(1.5M, 0M, 1M), 1M);
        }

        [Test]
        public void ShouldClampInt16ToMaximum()
        {
            Assert.AreEqual(Helpers.Math.Clamp((short) 10, (short) 0, (short) 5), 5);
        }

        [Test]
        public void ShouldClampUInt16ToMaximum()
        {
            Assert.AreEqual(Helpers.Math.Clamp((ushort) 10, (ushort) 0, (ushort) 5), 5);
        }

        [Test]
        public void ShouldClampInt32ToMaximum()
        {
            Assert.AreEqual(Helpers.Math.Clamp(10, 0, 5), 5);
        }

        [Test]
        public void ShouldClampUInt32ToMaximum()
        {
            Assert.AreEqual(Helpers.Math.Clamp((uint) 10, 0, 5), 5);
        }

        [Test]
        public void ShouldClampInt64ToMaximum()
        {
            Assert.AreEqual(Helpers.Math.Clamp((long) 10, 0, 5), 5);
        }

        [Test]
        public void ShouldClampUInt64ToMaximum()
        {
            Assert.AreEqual(Helpers.Math.Clamp((ulong) 10, 0, 5), 5);
        }

        [Test]
        public void ShouldClampByteToMaximum()
        {
            Assert.AreEqual(Helpers.Math.Clamp((byte) 10, (byte) 0, (byte) 5), 5);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void FloatClampShouldThrowArgumentException()
        {
            Helpers.Math.Clamp(0.5f, 1.0f, 0.0f);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void DoubleClampShouldThrowArgumentException()
        {
            Helpers.Math.Clamp(0.5, 1.0, 0.0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void DecimalClampShouldThrowArgumentException()
        {
            Helpers.Math.Clamp(0.5M, 1M, 0M);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Int16ClampShouldThrowArgumentException()
        {
            Helpers.Math.Clamp((short) 5, (short) 10, (short) 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void UInt16ClampShouldThrowArgumentException()
        {
            Helpers.Math.Clamp((ushort) 5, (ushort) 10, (ushort) 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Int32ClampShouldThrowArgumentException()
        {
            Helpers.Math.Clamp(5, 10, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void UInt32ClampShouldThrowArgumentException()
        {
            Helpers.Math.Clamp((uint) 5, 10, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Int64ClampShouldThrowArgumentException()
        {
            Helpers.Math.Clamp((long) 5, 10, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void UInt64ClampShouldThrowArgumentException()
        {
            Helpers.Math.Clamp((ulong) 5, 10, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void ByteClampShouldThrowArgumentException()
        {
            Helpers.Math.Clamp((byte) 5, (byte) 10, (byte) 0);
        }
    }
}
